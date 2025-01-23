using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvrakTakip.Data;
using EvrakTakip.Models;
using EvrakTakip.Models.ViewModel;
using EvrakTakip.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EvrakTakip.Pages.Bakimlar
{
    [Authorize(Roles = StatikRoller.AdminKullanici)]
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;


        [BindProperty]
        public EvrakBakimHizmetiViewModel EvrakBakimHizmetiViewModel { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(int evrakId)
        {
            EvrakBakimHizmetiViewModel = new EvrakBakimHizmetiViewModel
            {
                Evrak = await _db.Evrak.Include(a => a.ApplicationUser).FirstOrDefaultAsync(a => a.Id == evrakId),
                BakimHizmetGenel = new Models.BakimHizmetiGenel()
            };

            List<String> BakimHizmetiKartIciEvrakTipleriListesi = _db.BakimHizmetKart.Include(a => a.EvrakTipi).Where(a => a.EvrakId == evrakId).Select(a => a.EvrakTipi.EvrakAdi).ToList();
            IQueryable<EvrakTipi> BakimListesi = from x in _db.EvrakTipi where !(BakimHizmetiKartIciEvrakTipleriListesi.Contains(x.EvrakAdi)) select x;

            EvrakBakimHizmetiViewModel.EvrakTipleriListesi = BakimListesi.ToList();

            EvrakBakimHizmetiViewModel.BakimHizmetKart = _db.BakimHizmetKart.Include(a => a.EvrakTipi).Where(a => a.EvrakId == evrakId).ToList();

            EvrakBakimHizmetiViewModel.BakimHizmetGenel.ToplamFiyat = 0;

            foreach (var item in EvrakBakimHizmetiViewModel.BakimHizmetKart)
            {
                EvrakBakimHizmetiViewModel.BakimHizmetGenel.ToplamFiyat += item.EvrakTipi.EvrakFiyati;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                EvrakBakimHizmetiViewModel.BakimHizmetGenel.EklendigiTarih = DateTime.Now;
                EvrakBakimHizmetiViewModel.BakimHizmetKart = _db.BakimHizmetKart.Include(a => a.EvrakTipi).Where(a => a.EvrakId == EvrakBakimHizmetiViewModel.Evrak.Id).ToList();


                foreach (var item in EvrakBakimHizmetiViewModel.BakimHizmetKart)
                {
                    EvrakBakimHizmetiViewModel.BakimHizmetGenel.ToplamFiyat += item.EvrakTipi.EvrakFiyati;
                }


                EvrakBakimHizmetiViewModel.BakimHizmetGenel.EvrakId = EvrakBakimHizmetiViewModel.Evrak.Id;

                _db.BakimHizmetiGenel.Add(EvrakBakimHizmetiViewModel.BakimHizmetGenel);
                await _db.SaveChangesAsync();

                foreach (var detay in EvrakBakimHizmetiViewModel.BakimHizmetKart)
                {
                    BakimHizmetiDetay BakimHizmetiDetay = new BakimHizmetiDetay
                    {
                        BakimHizmetiGenelId = EvrakBakimHizmetiViewModel.BakimHizmetGenel.Id,
                        EvrakAdi = detay.EvrakTipi.EvrakAdi,
                        EvrakFiyati = detay.EvrakTipi.EvrakFiyati,
                        EvrakTipiId = detay.EvrakTipiId
                    };

                    _db.BakimHizmetiDetay.Add(BakimHizmetiDetay);
                }

                _db.BakimHizmetKart.RemoveRange(EvrakBakimHizmetiViewModel.BakimHizmetKart);

                await _db.SaveChangesAsync();

                return RedirectToPage("../Mevraklar/Index", new { kullaniciId = EvrakBakimHizmetiViewModel.Evrak.KullaniciId });

            }

            return Page();

        }

        public async Task<IActionResult> OnPostKartaEkleme()
        {
            BakimHizmetKart objBakimKarti = new BakimHizmetKart()
            {
                EvrakId = EvrakBakimHizmetiViewModel.Evrak.Id,
                EvrakTipiId = EvrakBakimHizmetiViewModel.BakimHizmetDetay.EvrakTipiId
            };

            _db.BakimHizmetKart.Add(objBakimKarti);
            await _db.SaveChangesAsync();
            return RedirectToPage("Create", new { evrakId = EvrakBakimHizmetiViewModel.Evrak.Id });
        }

        public async Task<IActionResult> OnPostKarttanSilme(int evrakTipiId)
        {
           BakimHizmetKart objBakimKarti = _db.BakimHizmetKart.FirstOrDefault(a => a.EvrakId == EvrakBakimHizmetiViewModel.Evrak.Id && a.EvrakTipiId == evrakTipiId);

           _db.BakimHizmetKart.Remove(objBakimKarti);
           await _db.SaveChangesAsync();

           return RedirectToPage("Create", new { evrakId = EvrakBakimHizmetiViewModel.Evrak.Id });
        }


    }
}
