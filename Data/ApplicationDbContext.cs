using Microsoft.EntityFrameworkCore;
using RentalManagementSystem.Models;

namespace RentalManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<RenterModel> Renters { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RenterModel>().HasData(
                new RenterModel { Id= 1, Name ="Hao"},
                new RenterModel { Id = 2, Name = "Hoa"},
                new RenterModel { Id = 3, Name = "Hai" }
            );
        }
    }
}
