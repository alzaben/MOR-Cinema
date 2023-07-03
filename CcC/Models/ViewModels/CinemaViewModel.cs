using CcC.Models.SharedProp;
using System.ComponentModel.DataAnnotations.Schema;

namespace CcC.Models.ViewModels
{
    public class CinemaViewModel:CommonProp
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IFormFile? Img { get; set; }
        public string? Location { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
