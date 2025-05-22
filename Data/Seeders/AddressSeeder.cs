using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Data.Seeders
{
    public static class AddressSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(
                new Address { Id = 1, StreetAddress = "ul. Kwiatowa 1", City = "Warszawa", PostalCode = "00-001", Country = "Polska" },
                new Address { Id = 2, StreetAddress = "ul. Leśna 5", City = "Kraków", PostalCode = "30-002", Country = "Polska" },
                new Address { Id = 3, StreetAddress = "ul. Słoneczna 10", City = "Poznań", PostalCode = "60-003", Country = "Polska" },
                new Address { Id = 4, StreetAddress = "ul. Morska 7", City = "Gdańsk", PostalCode = "80-004", Country = "Polska" },
                new Address { Id = 5, StreetAddress = "ul. Górska 15", City = "Zakopane", PostalCode = "34-500", Country = "Polska" },
                new Address { Id = 6, StreetAddress = "ul. Spacerowa 20", City = "Wrocław", PostalCode = "50-005", Country = "Polska" },
                new Address { Id = 7, StreetAddress = "ul. Zielona 3", City = "Lublin", PostalCode = "20-006", Country = "Polska" }
            );
        }
    }
}