using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace paylasimProject.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Kullanici Adi")]
        [DataType(DataType.Text)]
        public string Kullanici_Adi { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Sifre")]
        public string Sifre { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Kullanici Tipi")]
        public string KullaniciTipi { get; set; }

        //[Display(Name = "Remember me?")]
        //public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Ad")]
        public string Ad { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Soyad")]
        public string Soyad { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Adres")]
        public string Adres { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Telefon Numarasi")]
        public string Tel { get; set; }
        
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Kullanici Tipi")]
        public string Kullanici_Tipi { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Kullanici Adi")]
        public string Kullanici_Adi { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Sifre")]
        public string Sifre { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
//        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
