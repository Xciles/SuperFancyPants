using Microsoft.EntityFrameworkCore;
using SuperFancyWeb.Models;

namespace SuperFancyWeb.Data
{
    public class SuperDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }

        public SuperDbContext(DbContextOptions<SuperDbContext> options)
            : base(options)
        {
        }
    }
}
