using Microsoft.EntityFrameworkCore;
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
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            AddressSeeder.Seed(modelBuilder);
            AnimalSeeder.Seed(modelBuilder);
            AdoptionSeeder.Seed(modelBuilder);
            ScheduleSeeder.Seed(modelBuilder);
            DonationSeeder.Seed(modelBuilder);
            VolunteerSeeder.Seed(modelBuilder);

            // Konwersja DateTime -> UTC dla timestamp with time zone
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                    {
                        property.SetValueConverter(new Microsoft.EntityFrameworkCore.Storage.ValueConversion.ValueConverter<DateTime, DateTime>(
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc),  
                            v => DateTime.SpecifyKind(v, DateTimeKind.Utc)  
                        ));
                    }
                }
            }
        }

    }
}