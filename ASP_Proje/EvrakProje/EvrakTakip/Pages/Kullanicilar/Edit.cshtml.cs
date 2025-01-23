using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvrakTakip.Data;
using EvrakTakip.Models;
using EvrakTakip.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EvrakTakip.Pages.Kullanicilar
{
    [Authorize(Roles = StatikRoller.AdminKullanici)]
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }


        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id.Trim().Length == 0)
            {
                return NotFound();
            }

            ApplicationUser = await _db.ApplicationUser.FirstOrDefaultAsync(a => a.Id == id);

            if (ApplicationUser == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            else
            {
                var kullaniciDb = await _db.ApplicationUser.SingleOrDefaultAsync(a => a.Id == ApplicationUser.Id);

                if (kullaniciDb == null)
                {
                    return NotFound();
                }
                else
                {
                    kullaniciDb.AdSoyad = ApplicationUser.AdSoyad;
                    kullaniciDb.PhoneNumber = ApplicationUser.PhoneNumber;
                    kullaniciDb.Adres = ApplicationUser.Adres;
                    kullaniciDb.Sehir = ApplicationUser.Sehir;
                    kullaniciDb.PostaKodu = ApplicationUser.PostaKodu;

                    await _db.SaveChangesAsync();
                    return RedirectToPage("Index");
                }
            }
        }
    }
}
