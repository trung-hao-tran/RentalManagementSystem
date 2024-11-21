using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RentalManagementSystem.Models;

namespace RentalManagementSystem.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public required DbSet<RenterModel> Renters { get; set; }
        public required DbSet<PropertyModel> Properties { get; set; }
        public required DbSet<UtilityModel> Utilities { get; set; }
        public required DbSet<UtilityProfile> UtilityProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PropertyModel -> RenterModel (One-to-Many)
            modelBuilder.Entity<RenterModel>()
                .HasOne(r => r.Property) 
                .WithMany(p => p.Renters) 
                .HasForeignKey(r => r.PropertyId)
                .OnDelete(DeleteBehavior.Cascade);

            // UtilityModel -> UtilityProfile (Many-to-One)
            modelBuilder.Entity<UtilityModel>()
                .HasOne(u => u.UtilityProfile) 
                .WithMany(up => up.Utilities) 
                .HasForeignKey(u => u.UtilityProfileId) 
                .OnDelete(DeleteBehavior.Cascade); 

            // PropertyModel -> UtilityProfile (One-to-One or None)
            modelBuilder.Entity<PropertyModel>()
                .HasOne(p => p.UtilityProfile) 
                .WithMany(up => up.Properties) 
                .HasForeignKey(p => p.UtilityProfileId) 
                .IsRequired(false) 
                .OnDelete(DeleteBehavior.SetNull); 

            modelBuilder.Entity<RenterModel>().HasData(
                new RenterModel { Id= 1, Name ="Hao",PropertyId=1},
                new RenterModel { Id = 2, Name = "Hoa", PropertyId = 1 },
                new RenterModel { Id = 3, Name = "Hai", PropertyId = 2 }
            );

            modelBuilder.Entity<PropertyModel>().HasData(
                new PropertyModel { Id = 1, BlockNumber = 'A', Price = 100, UnitNumber = 1, UtilityProfileId=1 },
                new PropertyModel { Id = 3, BlockNumber = 'D', Price = 100, UnitNumber = 69, UtilityProfileId=null },
                new PropertyModel { Id = 2, BlockNumber = 'A', Price = 100, UnitNumber = 2, UtilityProfileId = 2 });

            modelBuilder.Entity<UtilityProfile>().HasData(
                new UtilityProfile { Id = 1, Name = "Basic Utilities" },
                new UtilityProfile { Id = 2, Name = "Premium Utilities" }
            );

            modelBuilder.Entity<UtilityModel>().HasData(
                new UtilityModel { Id = 1, Name = "Water", Price = 50, UtilityProfileId = 1 },
                new UtilityModel { Id = 2, Name = "Electricity", Price = 100, UtilityProfileId = 1 },
                new UtilityModel { Id = 3, Name = "Gas", Price = 80, UtilityProfileId = 2 }
            );

        }
        public DbSet<RentalManagementSystem.Models.UtilityProfile> UtilityProfile { get; set; } = default!;
    }
}
