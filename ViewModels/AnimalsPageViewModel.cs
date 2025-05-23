using System.Collections.ObjectModel;
using AnimalShelter.Models;
using AnimalShelter.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AnimalShelter.ViewModels;

public partial class AnimalsPageViewModel : ViewModelBase
{
    private readonly AnimalShelterDbContext _dbContext;

    public ObservableCollection<Animal> Animals { get; set; } = new();

    public AnimalsPageViewModel(AnimalShelterDbContext dbContext)
    {
        _dbContext = dbContext;
        LoadAnimals();
    }

    private void LoadAnimals()
    {
        // Ensure DB is created
        _dbContext.Database.EnsureCreated();

        var animalsFromDb = _dbContext.Animals.ToList();

        Animals.Clear();
        foreach (var animal in animalsFromDb)
        {
            Animals.Add(animal);
        }
    }
}
