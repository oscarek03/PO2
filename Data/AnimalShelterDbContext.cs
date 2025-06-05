using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using AnimalShelter.Models;
using AnimalShelter.Data.Seeders;
using System;

namespace AnimalShelter.Data
{
    public class AnimalShelterDbContext : DbContext
    {
        public AnimalShelterDbContext(DbContextOptions<AnimalShelterDbContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Adoption> Adoptions { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>()
                .HaveConversion<UtcValueConverter>();
            
            configurationBuilder.Properties<DateTime?>()
                .HaveConversion<UtcValueConverter>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            AddressSeeder.Seed(modelBuilder);
            AnimalSeeder.Seed(modelBuilder);
            AdoptionSeeder.Seed(modelBuilder);
            VolunteerSeeder.Seed(modelBuilder);
        }
    }

    // Definicja konwertera UTC
    public class UtcValueConverter : ValueConverter<DateTime, DateTime>
    {
        public UtcValueConverter() : base(
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc),
            v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
        {
        }
    }
}