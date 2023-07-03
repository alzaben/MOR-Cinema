using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CcC.Models.SharedProp
{
    public class CommonProp
    {
        [Display(Name = "Creation Date")]
        public DateTime? CreationDate { get; set; } = DateTime.Now;
        [Display(Name = "Is Published")]
        public bool IsPublished { get; set; }
        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; }
        [Display(Name = "User ")]
        public string? UserId { get; set; }
    }
}
