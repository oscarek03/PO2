using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Data.Seeders
{
    public static class AnimalSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>().HasData(
                new Animal { Id = 1, Name = "Kajtek", Species = "Pies", Breed = "Mieszaniec", Age = 3, Gender = "Samiec", Color = "Czarny", Size = "Duży", Microchip = "1234567890", Location = "Boks 1", IsAdopted = true },
                new Animal { Id = 2, Name = "Luna", Species = "Kot", Breed = "Europejski", Age = 2, Gender = "Samica", Color = "Szary", Size = "Mały", Microchip = "0987654321", Location = "Boks 2", IsAdopted = false },
                new Animal { Id = 3, Name = "Sara", Species = "Pies", Breed = "Owczarek niemiecki", Age = 4, Gender = "Samica", Color = "Brązowy", Size = "Duży", Microchip = "2233445566", Location = "Boks 3", IsAdopted = false },
                new Animal { Id = 4, Name = "Benio", Species = "Pies", Breed = "Beagle", Age = 2, Gender = "Samiec", Color = "Tricolor", Size = "Średni", Microchip = "3344556677", Location = "Boks 4", IsAdopted = true },
                new Animal { Id = 5, Name = "Mila", Species = "Pies", Breed = "Mieszaniec", Age = 5, Gender = "Samica", Color = "Złoty", Size = "Duży", Microchip = "4455667788", Location = "Boks 5", IsAdopted = false },
                new Animal { Id = 6, Name = "Gucio", Species = "Pies", Breed = "Bulldog", Age = 6, Gender = "Samiec", Color = "Biały", Size = "Średni", Microchip = "5566778899", Location = "Boks 6", IsAdopted = false },
                new Animal { Id = 7, Name = "Tosia", Species = "Pies", Breed = "Mieszaniec", Age = 3, Gender = "Samica", Color = "Srebrny", Size = "Mały", Microchip = "6677889900", Location = "Boks 7", IsAdopted = false },
                new Animal { Id = 8, Name = "Felek", Species = "Pies", Breed = "Mieszaniec", Age = 1, Gender = "Samiec", Color = "Brązowy", Size = "Mały", Microchip = "7788990011", Location = "Boks 8", IsAdopted = false },
                new Animal { Id = 9, Name = "Leo", Species = "Kot", Breed = "Syjamski", Age = 5, Gender = "Samiec", Color = "Biały", Size = "Mały", Microchip = "8899001122", Location = "Boks 9", IsAdopted = true },
                new Animal { Id = 10, Name = "Klara", Species = "Kot", Breed = "Mieszaniec", Age = 3, Gender = "Samica", Color = "Biały", Size = "Mały", Microchip = "9900112233", Location = "Boks 10", IsAdopted = false },
                new Animal { Id = 11, Name = "Rufus", Species = "Kot", Breed = "Maine Coon", Age = 4, Gender = "Samiec", Color = "Rudy", Size = "Duży", Microchip = "1011121314", Location = "Boks 11", IsAdopted = false },
                new Animal { Id = 12, Name = "Zoe", Species = "Kot", Breed = "Mieszaniec", Age = 2, Gender = "Samica", Color = "Pręgowany", Size = "Średni", Microchip = "1213141516", Location = "Boks 12", IsAdopted = false },
                new Animal { Id = 13, Name = "Neo", Species = "Kot", Breed = "Sfinks", Age = 1, Gender = "Samiec", Color = "Beżowy", Size = "Mały", Microchip = "1314151617", Location = "Boks 13", IsAdopted = false },
                new Animal { Id = 14, Name = "Nina", Species = "Kot", Breed = "Mieszaniec", Age = 3, Gender = "Samica", Color = "Niebieski", Size = "Mały", Microchip = "1415161718", Location = "Boks 14", IsAdopted = false },
                new Animal { Id = 15, Name = "Czarek", Species = "Kot", Breed = "Mieszaniec", Age = 2, Gender = "Samiec", Color = "Czarny", Size = "Mały", Microchip = "1516171819", Location = "Boks 15", IsAdopted = false }
            );
        }
    }
}
