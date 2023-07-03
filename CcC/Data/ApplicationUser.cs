using CcC.Models;
using Microsoft.AspNetCore.Identity;

namespace CcC.Data
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Cart> Carts { get; set; }
    }
}
