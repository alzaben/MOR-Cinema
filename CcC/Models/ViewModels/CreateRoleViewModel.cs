using System.ComponentModel.DataAnnotations;

namespace CcC.Models.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string? RoleName { get; set; }
    }
}
