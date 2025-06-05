using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AnimalShelter.Data
{
    public class AnimalShelterDbContextFactory : IDesignTimeDbContextFactory<AnimalShelterDbContext>
    {
        public AnimalShelterDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<AnimalShelterDbContext>();
            optionsBuilder.UseSqlite(configuration.GetConnectionString("DefaultConnection"));

            return new AnimalShelterDbContext(optionsBuilder.Options);
        }
    }
}