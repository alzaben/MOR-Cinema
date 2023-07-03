using System.ComponentModel.DataAnnotations;

namespace CcC.Models
{
    public class FeedBack
    {
        public int FeedBackId { get; set; }
        [Required(ErrorMessage ="Please Enter Your Name")]
        [Display(Name="Your Name")]
        public string? Name { get; set;}
        [EmailAddress]
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string? Message { get; set; }

    }
}
