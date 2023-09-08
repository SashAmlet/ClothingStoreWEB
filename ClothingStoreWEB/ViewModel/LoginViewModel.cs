using System.ComponentModel.DataAnnotations;

namespace ClothingStoreWEB.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }

    }
}
