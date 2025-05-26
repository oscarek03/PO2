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
                new Animal { Id = 15, Name = "Czarek", Species = "Kot", Breed = "Mieszaniec", Age = 2, Gender = "Samiec", Color = "Czarny", Size = "Mały", Microchip = "1516171819", Location = "Boks 15", IsAdopted = false },
                new Animal { Id = 16, Name = "Borys", Species = "Pies", Breed = "Labrador", Age = 7, Gender = "Samiec", Color = "Czekoladowy", Size = "Duży", Microchip = "1617181920", Location = "Boks 16", IsAdopted = false },
                new Animal { Id = 17, Name = "Misia", Species = "Pies", Breed = "Shih Tzu", Age = 2, Gender = "Samica", Color = "Biały", Size = "Mały", Microchip = "1718192021", Location = "Boks 17", IsAdopted = true },
                new Animal { Id = 18, Name = "Riko", Species = "Pies", Breed = "Border Collie", Age = 4, Gender = "Samiec", Color = "Czarny", Size = "Średni", Microchip = "1819202122", Location = "Boks 18", IsAdopted = false },
                new Animal { Id = 19, Name = "Bella", Species = "Kot", Breed = "Brytyjski", Age = 3, Gender = "Samica", Color = "Szary", Size = "Mały", Microchip = "1920212223", Location = "Boks 19", IsAdopted = false },
                new Animal { Id = 20, Name = "Maks", Species = "Pies", Breed = "Golden Retriever", Age = 6, Gender = "Samiec", Color = "Złoty", Size = "Duży", Microchip = "2021222324", Location = "Boks 20", IsAdopted = false },
                new Animal { Id = 21, Name = "Daisy", Species = "Kot", Breed = "Perski", Age = 2, Gender = "Samica", Color = "Biały", Size = "Mały", Microchip = "2122232425", Location = "Boks 21", IsAdopted = false },
                new Animal { Id = 22, Name = "Tobi", Species = "Pies", Breed = "Jack Russell", Age = 1, Gender = "Samiec", Color = "Biały", Size = "Mały", Microchip = "2223242526", Location = "Boks 22", IsAdopted = false },
                new Animal { Id = 23, Name = "Mela", Species = "Kot", Breed = "Mieszaniec", Age = 5, Gender = "Samica", Color = "Czarny", Size = "Mały", Microchip = "2324252627", Location = "Boks 23", IsAdopted = true },
                new Animal { Id = 24, Name = "Simba", Species = "Pies", Breed = "Mieszaniec", Age = 3, Gender = "Samiec", Color = "Rudy", Size = "Średni", Microchip = "2425262728", Location = "Boks 24", IsAdopted = false },
                new Animal { Id = 25, Name = "Lili", Species = "Kot", Breed = "Syjamski", Age = 4, Gender = "Samica", Color = "Biały", Size = "Mały", Microchip = "2526272829", Location = "Boks 25", IsAdopted = false },
                new Animal { Id = 26, Name = "Oskar", Species = "Pies", Breed = "Dalmatyńczyk", Age = 2, Gender = "Samiec", Color = "Czarny-biały", Size = "Duży", Microchip = "2627282930", Location = "Boks 26", IsAdopted = false },
                new Animal { Id = 27, Name = "Maja", Species = "Kot", Breed = "Mieszaniec", Age = 3, Gender = "Samica", Color = "Biały-pręgowany", Size = "Mały", Microchip = "2728293031", Location = "Boks 27", IsAdopted = false },
                new Animal { Id = 28, Name = "Bambi", Species = "Pies", Breed = "Jamnik", Age = 5, Gender = "Samica", Color = "Brązowy", Size = "Mały", Microchip = "2829303132", Location = "Boks 28", IsAdopted = false },
                new Animal { Id = 29, Name = "Kuba", Species = "Kot", Breed = "Mieszaniec", Age = 6, Gender = "Samiec", Color = "Czarny", Size = "Mały", Microchip = "2930313233", Location = "Boks 29", IsAdopted = false },
                new Animal { Id = 30, Name = "Pola", Species = "Pies", Breed = "Sznaucer", Age = 4, Gender = "Samica", Color = "Srebrny", Size = "Średni", Microchip = "3031323334", Location = "Boks 30", IsAdopted = false },
                new Animal { Id = 31, Name = "Rysio", Species = "Kot", Breed = "Mieszaniec", Age = 2, Gender = "Samiec", Color = "Szary", Size = "Mały", Microchip = "3132333435", Location = "Boks 31", IsAdopted = false },
                new Animal { Id = 32, Name = "Kira", Species = "Pies", Breed = "Mieszaniec", Age = 1, Gender = "Samica", Color = "Biały", Size = "Mały", Microchip = "3233343536", Location = "Boks 32", IsAdopted = false },
                new Animal { Id = 33, Name = "Miki", Species = "Kot", Breed = "Mieszaniec", Age = 3, Gender = "Samiec", Color = "Pręgowany", Size = "Mały", Microchip = "3334353637", Location = "Boks 33", IsAdopted = false },
                new Animal { Id = 34, Name = "Fiona", Species = "Pies", Breed = "Mieszaniec", Age = 2, Gender = "Samica", Color = "Czarny", Size = "Średni", Microchip = "3435363738", Location = "Boks 34", IsAdopted = false },
                new Animal { Id = 35, Name = "Sonia", Species = "Kot", Breed = "Mieszaniec", Age = 4, Gender = "Samica", Color = "Szylkret", Size = "Mały", Microchip = "3536373839", Location = "Boks 35", IsAdopted = false },
                new Animal { Id = 36, Name = "Borys", Species = "Pies", Breed = "Owczarek podhalański", Age = 5, Gender = "Samiec", Color = "Biały", Size = "Duży", Microchip = "3637383940", Location = "Boks 36", IsAdopted = false },
                new Animal { Id = 37, Name = "Marta", Species = "Kot", Breed = "Mieszaniec", Age = 2, Gender = "Samica", Color = "Czarny", Size = "Mały", Microchip = "3738394041", Location = "Boks 37", IsAdopted = false },
                new Animal { Id = 38, Name = "Tytus", Species = "Pies", Breed = "Mieszaniec", Age = 3, Gender = "Samiec", Color = "Brązowy", Size = "Średni", Microchip = "3839404142", Location = "Boks 38", IsAdopted = false },
                new Animal { Id = 39, Name = "Lola", Species = "Kot", Breed = "Mieszaniec", Age = 1, Gender = "Samica", Color = "Biały", Size = "Mały", Microchip = "3940414243", Location = "Boks 39", IsAdopted = false },
                new Animal { Id = 40, Name = "Bingo", Species = "Pies", Breed = "Mieszaniec", Age = 2, Gender = "Samiec", Color = "Czarny", Size = "Duży", Microchip = "4041424344", Location = "Boks 40", IsAdopted = false }
            );
        }
    }
}
