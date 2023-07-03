using CcC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CcC.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<FeedBack> feedBacks { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Snack> snacks { get; set; }
        public DbSet<Cinema> cinemas { get; set; }
        public DbSet<Seat> seats { get; set; }





    }
}
