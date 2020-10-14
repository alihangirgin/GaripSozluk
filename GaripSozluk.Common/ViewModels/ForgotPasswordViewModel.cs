using System.ComponentModel.DataAnnotations;

namespace GaripSozluk.Common.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email zorunludur")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
