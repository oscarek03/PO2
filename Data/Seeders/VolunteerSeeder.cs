using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Data.Seeders
{
    public static class VolunteerSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Volunteer>().HasData(
                new Volunteer
                {
                    Id = 1,
                    FullName = "Piotr Zieliński",
                    Email = "piotr.zielinski@example.com",
                    PhoneNumber = "555666777",
                    StreetAddress = "ul. Polna 3",
                    City = "Gdańsk",
                    PostalCode = "80-001",
                    Roles = 1,
                    Availability = 3,
                    AdditionalNotes = "Może pracować w weekendy"
                },
                new Volunteer
                {
                    Id = 2,
                    FullName = "Anna Maj",
                    Email = "anna.maj@example.com",
                    PhoneNumber = "600700800",
                    StreetAddress = "ul. Wiosenna 4",
                    City = "Warszawa",
                    PostalCode = "00-002",
                    Roles = 2,
                    Availability = 2,
                    AdditionalNotes = "Dostępna popołudniami"
                },
                new Volunteer
                {
                    Id = 3,
                    FullName = "Tomasz Nowak",
                    Email = "tomasz.nowak@example.com",
                    PhoneNumber = "601701801",
                    StreetAddress = "ul. Jesienna 8",
                    City = "Kraków",
                    PostalCode = "30-003",
                    Roles = 1,
                    Availability = 1,
                    AdditionalNotes = "Może pracować tylko w poniedziałki"
                },
                new Volunteer
                {
                    Id = 4,
                    FullName = "Karolina Wiśniewska",
                    Email = "karolina.wisniewska@example.com",
                    PhoneNumber = "602702802",
                    StreetAddress = "ul. Letnia 12",
                    City = "Poznań",
                    PostalCode = "60-004",
                    Roles = 3,
                    Availability = 2,
                    AdditionalNotes = "Lubi pracować ze zwierzętami starszymi"
                },
                new Volunteer
                {
                    Id = 5,
                    FullName = "Marek Lewandowski",
                    Email = "marek.lewandowski@example.com",
                    PhoneNumber = "603703803",
                    StreetAddress = "ul. Zimowa 16",
                    City = "Wrocław",
                    PostalCode = "50-005",
                    Roles = 2,
                    Availability = 3,
                    AdditionalNotes = "Dostępny w weekendy"
                },
                new Volunteer
                {
                    Id = 6,
                    FullName = "Ewa Kaczmarek",
                    Email = "ewa.kaczmarek@example.com",
                    PhoneNumber = "604704804",
                    StreetAddress = "ul. Spacerowa 20",
                    City = "Lublin",
                    PostalCode = "20-006",
                    Roles = 1,
                    Availability = 1,
                    AdditionalNotes = "Może pomagać przy adopcjach"
                },
                new Volunteer
                {
                    Id = 7,
                    FullName = "Grzegorz Lis",
                    Email = "grzegorz.lis@example.com",
                    PhoneNumber = "605705805",
                    StreetAddress = "ul. Zielona 3",
                    City = "Zakopane",
                    PostalCode = "34-500",
                    Roles = 3,
                    Availability = 2,
                    AdditionalNotes = "Zainteresowany opieką nad psami"
                },
                new Volunteer
                {
                    Id = 8,
                    FullName = "Magdalena Bąk",
                    Email = "magdalena.bak@example.com",
                    PhoneNumber = "606706806",
                    StreetAddress = "ul. Słoneczna 10",
                    City = "Gdynia",
                    PostalCode = "81-007",
                    Roles = 2,
                    Availability = 3,
                    AdditionalNotes = "Pomoc w organizacji wydarzeń"
                }
            );
        }
    }
}
