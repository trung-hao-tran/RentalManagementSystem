using Microsoft.EntityFrameworkCore;
using RentalManagementSystem.Models;

namespace RentalManagementSystem.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public required DbSet<RenterModel> Renters { get; set; }
        public required DbSet<PropertyModel> Properties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RenterModel>().HasData(
                new RenterModel { Id= 1, Name ="Hao",PropertyId=1},
                new RenterModel { Id = 2, Name = "Hoa", PropertyId = 1 },
                new RenterModel { Id = 3, Name = "Hai", PropertyId = 2 }
            );

            modelBuilder.Entity<PropertyModel>().HasData(
                new PropertyModel { Id = 1, BlockNumber = 'A', Price = 100, UnitNumber = 1 },
                new PropertyModel { Id = 2, BlockNumber = 'A', Price = 100, UnitNumber = 2 });

        }
    }
}
