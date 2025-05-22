using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AnimalShelter.Data.Seeders
{
    public static class DonationSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donation>().HasData(
                new Donation
                {
                    Id = 1,
                    DonorName = "Anna Nowak",
                    Email = "anna.nowak@example.com",
                    PhoneNumber = "987654321",
                    Amount = 100,
                    DonationType = "Pieniądze",
                    PaymentMethod = "Przelew",
                    DonationDate = DateTime.SpecifyKind(new DateTime(2024, 4, 15), DateTimeKind.Utc),
                    NotesOrDedication = "Dla zwierząt"
                },
                new Donation
                {
                    Id = 2,
                    DonorName = "Jan Kowalski",
                    Email = "jan.kowalski@example.com",
                    PhoneNumber = "123456789",
                    Amount = 50,
                    DonationType = "Karma",
                    PaymentMethod = "Osobiście",
                    DonationDate = DateTime.SpecifyKind(new DateTime(2024, 4, 20), DateTimeKind.Utc),
                    NotesOrDedication = "Karma dla psów"
                },
                new Donation
                {
                    Id = 3,
                    DonorName = "Piotr Zieliński",
                    Email = "piotr.zielinski@example.com",
                    PhoneNumber = "555666777",
                    Amount = 200,
                    DonationType = "Pieniądze",
                    PaymentMethod = "Karta",
                    DonationDate = DateTime.SpecifyKind(new DateTime(2024, 5, 2), DateTimeKind.Utc),
                    NotesOrDedication = "Na leczenie kotów"
                },
                new Donation
                {
                    Id = 4,
                    DonorName = "Maria Wiśniewska",
                    Email = "maria.wisniewska@example.com",
                    PhoneNumber = "888999000",
                    Amount = 75,
                    DonationType = "Akcesoria",
                    PaymentMethod = "Osobiście",
                    DonationDate = DateTime.SpecifyKind(new DateTime(2024, 5, 10), DateTimeKind.Utc),
                    NotesOrDedication = "Zabawki dla zwierząt"
                },
                new Donation
                {
                    Id = 5,
                    DonorName = "Tomasz Lewandowski",
                    Email = "tomasz.lewandowski@example.com",
                    PhoneNumber = "111222333",
                    Amount = 120,
                    DonationType = "Pieniądze",
                    PaymentMethod = "Przelew",
                    DonationDate = DateTime.SpecifyKind(new DateTime(2024, 5, 18), DateTimeKind.Utc),
                    NotesOrDedication = "Dla schroniska"
                },
                new Donation
                {
                    Id = 6,
                    DonorName = "Karolina Maj",
                    Email = "karolina.maj@example.com",
                    PhoneNumber = "444555666",
                    Amount = 60,
                    DonationType = "Karma",
                    PaymentMethod = "Osobiście",
                    DonationDate = DateTime.SpecifyKind(new DateTime(2024, 5, 25), DateTimeKind.Utc),
                    NotesOrDedication = "Karma dla kotów"
                },
                new Donation
                {
                    Id = 7,
                    DonorName = "Grzegorz Nowak",
                    Email = "grzegorz.nowak@example.com",
                    PhoneNumber = "777888999",
                    Amount = 150,
                    DonationType = "Pieniądze",
                    PaymentMethod = "Karta",
                    DonationDate = DateTime.SpecifyKind(new DateTime(2024, 6, 1), DateTimeKind.Utc),
                    NotesOrDedication = "Wsparcie ogólne"
                }
            );
        }
    }
}
