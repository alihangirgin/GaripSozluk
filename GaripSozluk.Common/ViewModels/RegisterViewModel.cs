using System.ComponentModel.DataAnnotations;

namespace GaripSozluk.Common.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email zorunludur")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur")]
        [StringLength(100, ErrorMessage = "{0} en az {2} ve en çok {1} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler aynı olmalıdır.")]
        public string ConfirmPassword { get; set; }
    }
}
