using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Driving License")]
        public  string DrivingLicense { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}