using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EvrakTakip.Data;
using EvrakTakip.Models;
using EvrakTakip.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace EvrakTakip.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public RegisterModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _db = db;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress(ErrorMessage = "Geçerli Bir Email Adresi Giriniz")]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "{0} en az {2} ve en çok {1} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Şifre")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Şifre Doğrulama")]
            [Compare("Password", ErrorMessage = "Şifre ve Şifre Doğrulama alanları eşleşmiyor.")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string AdSoyad { get; set; }
            public string Adres { get; set; }
            public string Sehir { get; set; }
            public string PostaKodu { get; set; }

            [Required]
            public string PhoneNumber { get; set; }
            public bool AdminMi { get; set; }

        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                { 
                    UserName = Input.Email,
                    Email = Input.Email,
                    AdSoyad = Input.AdSoyad,
                    Adres = Input.Adres,
                    Sehir = Input.Sehir,
                    PostaKodu = Input.PostaKodu,
                    PhoneNumber = Input.PhoneNumber
                };

                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (!await _roleManager.RoleExistsAsync(StatikRoller.AdminKullanici))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(StatikRoller.AdminKullanici));
                    }

                    if (!await _roleManager.RoleExistsAsync(StatikRoller.MusteriKullanici))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(StatikRoller.MusteriKullanici));
                    }


                    if (Input.AdminMi)
                    {
                        await _userManager.AddToRoleAsync(user, StatikRoller.AdminKullanici);


                       ///
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                            protocol: Request.Scheme);

                        await _emailSender.SendEmailAsync(Input.Email, "Email adresinizi doğrulayınız",
                            $"Lütfen hesabınızı<a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>buraya tıklayarak doğrulayınız</a>.");

                        return RedirectToPage("/Kullanicilar/Index");
                    }

                    else
                    {

                        //!!!
                        await _userManager.AddToRoleAsync(user, StatikRoller.MusteriKullanici);

                        //await _signInManager.SignInAsync(user, isPersistent: false);

                        if (User.IsInRole(StatikRoller.AdminKullanici))
                        {
                            return RedirectToPage("/Kullanicilar/Index");
                        }
                        else
                        {
                            return LocalRedirect(returnUrl);
                        }



                    }


                    _logger.LogInformation("User created a new account with password.");


                    //if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    //{
                    //    return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    //}
                    //else
                    //{
                    //    await _signInManager.SignInAsync(user, isPersistent: false);
                    //    return LocalRedirect(returnUrl);
                    //}
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
