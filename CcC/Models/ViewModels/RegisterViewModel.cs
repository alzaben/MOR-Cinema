using System.ComponentModel.DataAnnotations;

namespace CcC.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please Enter Your Name")]

        public string? UserName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Please Confirm Your Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "passowrd not match")]
        public string? ConfirmPassword { get; set; }
        public string? Phone { get; set; }
    }
}
