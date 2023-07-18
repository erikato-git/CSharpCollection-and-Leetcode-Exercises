using System.ComponentModel.DataAnnotations;

namespace ASPNET_Identity_MVC.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }



    }
}
