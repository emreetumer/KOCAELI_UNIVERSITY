using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EvrakTakip.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace EvrakTakip.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext _db;

        public IndexModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, ApplicationDbContext db)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [EmailAddress]
            public string Email { get; set; }

            [Phone]
            [Display(Name = "Telefon Numarası")]
            public string PhoneNumber { get; set; }

            [Required]
            [Display(Name = "Ad-Soyad")]
            public string AdSoyad { get; set; }

            [Display(Name = "Adres")]
            public string Adres { get; set; }

            [Display(Name = "Şehir")]
            public string Sehir { get; set; }

            [Display(Name = "Posta Kodu")]
            public string PostaKodu { get; set; }
        }

        private async Task LoadAsync(IdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            var DbKullanici = await _db.ApplicationUser.FirstOrDefaultAsync(a => a.Email == user.Email);

            Username = DbKullanici.UserName;

            Input = new InputModel
            {
                AdSoyad = DbKullanici.AdSoyad,
                Email = DbKullanici.Email,
                PhoneNumber = DbKullanici.PhoneNumber,
                Adres = DbKullanici.Adres,
                Sehir = DbKullanici.Sehir,
                PostaKodu = DbKullanici.PostaKodu
            };

            await LoadAsync(user);
            return Page();
        }




        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }


            var DbKullanici = await _db.ApplicationUser.FirstOrDefaultAsync(a => a.Email == user.Email);

            DbKullanici.AdSoyad = Input.AdSoyad;
            DbKullanici.Adres = Input.Adres;
            DbKullanici.Sehir = Input.Sehir;
            DbKullanici.PostaKodu = Input.PostaKodu;
            DbKullanici.PhoneNumber = Input.PhoneNumber;

            await _db.SaveChangesAsync();

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Profiliniz Güncellenmiştir";
            return RedirectToPage();
        }
    }
}
