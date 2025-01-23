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

namespace EvrakTakip.Pages.Bakimlar
{
    [Authorize]
    public class BakimGecmisiModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public BakimGecmisiModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public List<BakimHizmetiGenel> BakimHizmetiGenel { get; set; }

        public string KullaniciId { get; set; }

        public async Task OnGet(int evrakId)
        {
            BakimHizmetiGenel = await _db.BakimHizmetiGenel.Include(a => a.Evrak).Include(b => b.Evrak.ApplicationUser).Where(b => b.EvrakId == evrakId).ToListAsync();

            KullaniciId = _db.Evrak.Where(u => u.Id == evrakId).ToList().FirstOrDefault().KullaniciId;
        }
    }
}
