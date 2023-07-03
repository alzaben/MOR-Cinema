using CcC.Models.SharedProp;

namespace CcC.Models.ViewModels
{
	public class SliderViewModel:CommonProp
	{
		public int SliderId { get; set; }
		public string? Title { get; set; }
		public string? SubTitle { get; set; }
		public int Rate { get; set; }
		public string? SliderDescription { get; set; }
		public string? starring { get; set; }
		public string? Genres { get; set; }
		public string? Runtime { get; set; }
		public string? Traller { get; set; }
		public IFormFile? Img { get; set; }
	}
}
