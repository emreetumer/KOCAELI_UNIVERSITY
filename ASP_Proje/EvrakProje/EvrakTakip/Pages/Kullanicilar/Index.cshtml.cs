using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EvrakTakip.Data;
using EvrakTakip.Models;
using EvrakTakip.Models.ViewModel;
using EvrakTakip.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EvrakTakip.Pages.Kullanicilar
{
    [Authorize(Roles = StatikRoller.AdminKullanici)]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public UsersListViewModel UsersListViewModel { get; set; }

        public async Task<IActionResult> OnGet(int productPage = 1, string aramaAdSoyad = null, string aramaEmail = null, string aramaTelefon = null)
        {
            UsersListViewModel = new UsersListViewModel()
            {
                ApplicationUserList = await _db.ApplicationUser.ToListAsync()
            };

            StringBuilder param = new StringBuilder();
            param.Append("/Kullanicilar?productPage=:");

            param.Append("&aramaAdSoyad=");
            if (aramaAdSoyad != null)
            {
                param.Append(aramaAdSoyad);
            }

            param.Append("&aramaEmail=");
            if (aramaEmail != null)
            {
                param.Append(aramaEmail);
            }


            param.Append("&aramaTelefon=");
            if (aramaTelefon != null)
            {
                param.Append(aramaTelefon);
            }

            if (aramaAdSoyad != null)
            {
                UsersListViewModel.ApplicationUserList = await _db.ApplicationUser.Where(a => a.AdSoyad.ToLower().Contains(aramaAdSoyad.ToLower())).ToListAsync();
            }

            else
            {
                if (aramaEmail != null)
                {
                    UsersListViewModel.ApplicationUserList = await _db.ApplicationUser.Where(a => a.Email.ToLower().Contains(aramaEmail.ToLower())).ToListAsync();
                }
                else
                {
                    if (aramaTelefon != null)
                    {
                        UsersListViewModel.ApplicationUserList = await _db.ApplicationUser.Where(a => a.PhoneNumber.ToLower().Contains(aramaTelefon.ToLower())).ToListAsync();
                    }
                }
            }



            var sayi = UsersListViewModel.ApplicationUserList.Count;

            UsersListViewModel.PagingInfo = new PagingInfo()
            {
                CurrentPage = productPage,
                ItemsPerPage = StatikRoller.KullaniciSayfalamaSayfaBoyutu,
                TotalItems = sayi,
                UrlParam = param.ToString()
            };

            UsersListViewModel.ApplicationUserList = UsersListViewModel.ApplicationUserList.OrderBy(a => a.Email).Skip((productPage - 1) * StatikRoller.KullaniciSayfalamaSayfaBoyutu).Take(StatikRoller.KullaniciSayfalamaSayfaBoyutu).ToList();

            return Page();
        }
    }
}
