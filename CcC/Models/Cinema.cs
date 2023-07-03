using CcC.Models.SharedProp;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CcC.Models
{
    public class Cinema:CommonProp
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="cinema name")]
        public string? Name { get; set; }
        public string? Img { get; set; }
       
        public string? Location { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; } 
        public Movie Movie { get; set; } 
    }
}
