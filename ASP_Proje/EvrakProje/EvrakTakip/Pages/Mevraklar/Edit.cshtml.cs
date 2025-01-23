using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvrakTakip.Data;
using EvrakTakip.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EvrakTakip.Pages.Mevraklar
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Evrak Evrak { get; set; }

        [TempData]
        public string DurumMesaj { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Evrak = await _db.Evrak.Include(a => a.ApplicationUser).FirstOrDefaultAsync(b => b.Id == id);

            if (Evrak == null)
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

           _db.Attach(Evrak).State = EntityState.Modified;

            await _db.SaveChangesAsync();
           DurumMesaj = "Evrak Bilgisi Güncellenmiþtir.";
           return RedirectToPage("./Index", new { kullaniciId = Evrak.KullaniciId });
        }
    }
}
