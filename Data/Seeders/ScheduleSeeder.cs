using AnimalShelter.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AnimalShelter.Data.Seeders
{
    public static class ScheduleSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Schedule>().HasData(
                new Schedule
                {
                    Id = 1,
                    EventDate = DateTime.SpecifyKind(new DateTime(2024, 6, 1, 10, 0, 0), DateTimeKind.Utc),
                    Title = "Dzień otwarty",
                    Note = "Zapraszamy wszystkich!",
                    EventType = "Wydarzenie"
                }
            );
        }
    }
}