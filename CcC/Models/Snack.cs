using CcC.Models.SharedProp;
using System.ComponentModel.DataAnnotations.Schema;

namespace CcC.Models
{
	public class Snack:CommonProp
	{
        public int SnackId { get; set; }
        public string? SnackName { get; set; }
        public decimal Price { get; set; }
       
	}
}
