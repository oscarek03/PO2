using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AnimalShelter.Data.Seeders
{
    public static class AdoptionSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adoption>().HasData(
                new Adoption
                {
                    Id = 1,
                    AnimalId = 1, 
                    FullName = "Jan Kowalski",
                    Email = "jan.kowalski@example.com",
                    PhoneNumber = "123456789",
                    AdoptionDate = DateTime.SpecifyKind(new DateTime(2024, 5, 1), DateTimeKind.Utc),
                    AddressId = 1,
                    Notes = "Brak uwag"
                },
                new Adoption
                {
                    Id = 2,
                    AnimalId = 9, 
                    FullName = "Anna Nowak",
                    Email = "anna.nowak@example.com",
                    PhoneNumber = "987654321",
                    AdoptionDate = DateTime.SpecifyKind(new DateTime(2024, 5, 15), DateTimeKind.Utc),
                    AddressId = 3,
                    Notes = "Adopcja przebiegła pomyślnie"
                },
                new Adoption
                {
                    Id = 3,
                    AnimalId = 4,
                    FullName = "Piotr Zieliński",
                    Email = "piotr.zielinski@example.com",
                    PhoneNumber = "555666777",
                    AdoptionDate = DateTime.SpecifyKind(new DateTime(2024, 6, 2), DateTimeKind.Utc),
                    AddressId = 5,
                    Notes = "Nowy dom z ogrodem"
                }
            );
        }
    }
}