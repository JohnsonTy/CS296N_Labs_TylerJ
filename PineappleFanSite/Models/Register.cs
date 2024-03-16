using System.ComponentModel.DataAnnotations;

namespace PineappleFanSite.Models
{
    public class Register
    {
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter an email.")]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;    // Makes the value not null = string.empty

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        public bool RememberMe { get; set; }

    }
}