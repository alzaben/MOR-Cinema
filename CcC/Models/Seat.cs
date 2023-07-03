using System.ComponentModel.DataAnnotations.Schema;

namespace CcC.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public int Row { get; set; }
        public int Number { get; set; }
        [ForeignKey("Cinema")]
        public int CinemaId { get; set; }
        public Cinema Cinema { get; set; }
        public bool Reserved { get; set; }
    }
}
