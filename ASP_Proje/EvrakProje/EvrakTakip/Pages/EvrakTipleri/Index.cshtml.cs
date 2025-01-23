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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IList<EvrakTipi> EvrakTipi { get; set; }

        public async Task<IActionResult> OnGet()
        {
            EvrakTipi = await _db.EvrakTipi.ToListAsync();
            return Page();
        }
    }
}
