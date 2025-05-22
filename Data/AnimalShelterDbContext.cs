using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;
using AnimalShelter.Data.Seeders;

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
        }
    }
}