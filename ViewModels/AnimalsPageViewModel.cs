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

    private Animal? _selectedAnimal;
    public Animal? SelectedAnimal
    {
        get => _selectedAnimal;
        set => SetProperty(ref _selectedAnimal, value);
    }

    public AnimalsPageViewModel(AnimalShelterDbContext dbContext)
    {
        _dbContext = dbContext;
        LoadAnimals();
    }

    private void LoadAnimals()
    {
        _dbContext.Database.EnsureCreated();
        Animals.Clear();
        foreach (var animal in _dbContext.Animals.ToList())
        {
            Animals.Add(animal);
        }
    }

    public void AddAnimal(Animal newAnimal)
    {
        _dbContext.Animals.Add(newAnimal);
        _dbContext.SaveChanges();
        Animals.Add(newAnimal);
    }

    public void UpdateAnimal(Animal updatedAnimal)
    {
        var animal = _dbContext.Animals.Find(updatedAnimal.Id);
        if (animal != null)
        {
            _dbContext.Entry(animal).CurrentValues.SetValues(updatedAnimal);
            _dbContext.SaveChanges();
            LoadAnimals();
        }
    }

    public void DeleteAnimal(Animal animalToDelete)
    {
        if (animalToDelete != null)
        {
            _dbContext.Animals.Remove(animalToDelete);
            _dbContext.SaveChanges();
            Animals.Remove(animalToDelete);
        }
    }
}
