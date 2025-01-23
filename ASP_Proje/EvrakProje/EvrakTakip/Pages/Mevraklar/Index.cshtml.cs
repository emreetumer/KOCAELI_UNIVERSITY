using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EvrakTakip.Data;
using EvrakTakip.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EvrakTakip.Pages.Mevraklar
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public KullaniciEvrakViewModel KullaniciEvrakViewModel { get; set; }

        [TempData]
        public string DurumMesaj { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> OnGet(string kullaniciID = null)
        {
            if (kullaniciID == null)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
                kullaniciID = claim.Value;
            }

            KullaniciEvrakViewModel = new KullaniciEvrakViewModel()
            {
                Evraklar = await _db.Evrak.Where(a => a.KullaniciId == kullaniciID).ToListAsync(),
                KullaniciObj = await _db.ApplicationUser.FirstOrDefaultAsync(a => a.Id == kullaniciID)
            };

            return Page();
        }
    }
}
