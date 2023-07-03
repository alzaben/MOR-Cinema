using CcC.Models.SharedProp;
using System.ComponentModel.DataAnnotations;

namespace CcC.Models
{
	public class Category:CommonProp
	{
		public int CategoryId { get; set; }
		[Required]
		[Display(Name = "CategoryName")]
		public string? CategoryName { get; set; }
	}
}
