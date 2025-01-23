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
    public class DetaylarModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DetaylarModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public BakimHizmetiGenel bakimHizmetiGenel { get; set; }
        public List<BakimHizmetiDetay> bakimHizmetiDetay { get; set; }
        public void OnGet(int evrakId)
        {
            bakimHizmetiGenel = _db.BakimHizmetiGenel.Include(a => a.Evrak).Include(a => a.Evrak.ApplicationUser).FirstOrDefault(a => a.Id == evrakId);

            bakimHizmetiDetay = _db.BakimHizmetiDetay.Where(a => a.BakimHizmetiGenelId == evrakId).ToList();
        }
    }
}
