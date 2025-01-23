using EvrakTakip.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace EvrakTakip.ViewComponents
{
    public class KullaniciAdiViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _db;

        public KullaniciAdiViewComponent(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var dbKullanici = await _db.ApplicationUser.FirstOrDefaultAsync(a => a.Id == claims.Value);

            return View(dbKullanici);
        }
    }
}
