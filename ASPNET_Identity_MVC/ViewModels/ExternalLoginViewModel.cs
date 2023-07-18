using System.ComponentModel.DataAnnotations;

namespace ASPNET_Identity_MVC.ViewModels
{
    public class ExternalLoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]

        public string Name { get; set; }
    }
}
