using PizzaPlanet.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace PizzaPlanet.Repositories
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options)
            : base(options)
        { }

        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLink> OrderLinks { get; set; }

    }
}    