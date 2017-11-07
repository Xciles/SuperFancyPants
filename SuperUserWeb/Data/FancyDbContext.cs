using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SuperUserWeb.Domain;

namespace SuperUserWeb.Data
{
    public class FancyDbContext : IdentityDbContext<UserAccount>
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public FancyDbContext(DbContextOptions<FancyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }

    public class DesignTimeTemporaryDbContextFactory : IDesignTimeDbContextFactory<FancyDbContext>
    {
        public FancyDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FancyDbContext>();
            builder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-SuperUserWeb-5C7D4BB4-443E-4BBB-B381-6BDE50696D7E;Trusted_Connection=True;MultipleActiveResultSets=true",
                optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(FancyDbContext).GetTypeInfo().Assembly.GetName().Name));
            return new FancyDbContext(builder.Options);
        }
    }
}
