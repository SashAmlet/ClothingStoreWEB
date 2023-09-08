using System.ComponentModel.DataAnnotations;

namespace ClothingStoreWEB.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;

        [Required]
        [Display(Name = "First name")]
        [DataType(DataType.Text)]
        public string FName { get; set; } = null!;

        [Required]
        [Display(Name = "Last name")]
        [DataType(DataType.Text)]
        public string LName { get; set; } = null!;

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Required]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        [Display(Name = "Confirm password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; } = null!;
    }
}
