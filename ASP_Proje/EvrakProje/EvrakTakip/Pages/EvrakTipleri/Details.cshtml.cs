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

namespace EvrakTakip.Pages.EvrakTipleri
{
    [Authorize(Roles = StatikRoller.AdminKullanici)]
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DetailsModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public EvrakTipi EvrakTipi { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EvrakTipi = await _db.EvrakTipi.FirstOrDefaultAsync(a => a.Id == id);

            if (EvrakTipi == null)
            {
                return NotFound();
            }

            return Page();

        }
    }
}
