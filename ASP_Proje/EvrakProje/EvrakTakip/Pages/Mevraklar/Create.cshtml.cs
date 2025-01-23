using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EvrakTakip.Data;
using EvrakTakip.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EvrakTakip.Pages.Mevraklar
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;


        [BindProperty]
        public Evrak Evrak { get; set; }

        [TempData]
        public string DurumMesaj { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet(string userId = null)
        {
            Evrak = new Evrak();
            {
                if (userId == null)
                {
                    var claimsIdentity = (ClaimsIdentity)User.Identity;
                    var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                    userId = claim.Value;
                }

                Evrak.KullaniciId = userId;
                return Page();

            }


        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Evrak.Add(Evrak);
            await _db.SaveChangesAsync();
            DurumMesaj = "Evrak Bilgileri Kaydedilmiþtir!";
            return RedirectToPage("Index", new { kullaniciId = Evrak.KullaniciId });


        }
    }
}
