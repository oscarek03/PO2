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
                    AddressId = 7,
                    AdditionalNotes = "Może pracować w weekendy"
                },
                new Volunteer
                {
                    Id = 2,
                    FullName = "Anna Maj",
                    Email = "anna.maj@example.com",
                    PhoneNumber = "600700800",
                    AddressId = 6,
                    AdditionalNotes = "Dostępna popołudniami"
                },
                new Volunteer
                {
                    Id = 3,
                    FullName = "Tomasz Nowak",
                    Email = "tomasz.nowak@example.com",
                    PhoneNumber = "601701801",
                    AddressId = 1,
                    AdditionalNotes = "Może pracować tylko w poniedziałki"
                },
                new Volunteer
                {
                    Id = 4,
                    FullName = "Karolina Wiśniewska",
                    Email = "karolina.wisniewska@example.com",
                    PhoneNumber = "602702802",
                    AddressId = 1,
                    AdditionalNotes = "Lubi pracować ze zwierzętami starszymi"
                },
                new Volunteer
                {
                    Id = 5,
                    FullName = "Marek Lewandowski",
                    Email = "marek.lewandowski@example.com",
                    PhoneNumber = "603703803",
                    AddressId = 2,
                    AdditionalNotes = "Dostępny w weekendy"
                },
                new Volunteer
                {
                    Id = 6,
                    FullName = "Ewa Kaczmarek",
                    Email = "ewa.kaczmarek@example.com",
                    PhoneNumber = "604704804",
                    AddressId = 3,
                    AdditionalNotes = "Może pomagać przy adopcjach"
                },
                new Volunteer
                {
                    Id = 7,
                    FullName = "Grzegorz Lis",
                    Email = "grzegorz.lis@example.com",
                    PhoneNumber = "605705805",
                    AddressId = 4,
                    AdditionalNotes = "Zainteresowany opieką nad psami"
                },
                new Volunteer
                {
                    Id = 8,
                    FullName = "Magdalena Bąk",
                    Email = "magdalena.bak@example.com",
                    PhoneNumber = "606706806",
                    AddressId = 5,
                    AdditionalNotes = "Pomoc w organizacji wydarzeń"
                }
            );
        }
    }
}
