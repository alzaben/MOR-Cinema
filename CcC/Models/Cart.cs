using CcC.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CcC.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public string? ProductName { get; set; }
        public decimal? Price { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }



    }
}
