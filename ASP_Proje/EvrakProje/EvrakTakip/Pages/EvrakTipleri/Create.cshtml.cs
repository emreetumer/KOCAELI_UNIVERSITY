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

namespace EvrakTakip.Pages.EvrakTipleri
{
    [Authorize(Roles = StatikRoller.AdminKullanici)]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public EvrakTipi EvrakTipi { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.EvrakTipi.Add(EvrakTipi);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
