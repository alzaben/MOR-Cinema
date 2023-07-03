using CcC.Models.SharedProp;
using System.ComponentModel.DataAnnotations.Schema;

namespace CcC.Models.ViewModels
{
	public class SnackViewModel:CommonProp
	{
		public int SnackId { get; set; }
		public string? SnackName { get; set; }
		public decimal Price { get; set; }
		
	}
}
