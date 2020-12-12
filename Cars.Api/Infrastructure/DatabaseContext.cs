using Cars.Domain.Models;
using Cars.Domain.Seeds;
using Microsoft.EntityFrameworkCore;

namespace Cars.Api.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>().HasData(DataSeed.Manufacturers);
            modelBuilder.Entity<Car>().HasData(DataSeed.Cars);
        }
    }
}