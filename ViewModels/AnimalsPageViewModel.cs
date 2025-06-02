using System.Collections.ObjectModel;
using AnimalShelter.Models;
using AnimalShelter.Data;
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
        set 
        { 
            SetProperty(ref _selectedAnimal, value);
            if (value != null)
            {
                // Kopiuj dane do formularza
                EditedAnimal = new Animal
                {
                    Id = value.Id,
                    Name = value.Name,
                    Species = value.Species,
                    Breed = value.Breed,
                    Age = value.Age,
                    Gender = value.Gender,
                    Color = value.Color,
                    Size = value.Size,
                    Microchip = value.Microchip,
                    Location = value.Location,
                    IsAdopted = value.IsAdopted
                };
            }
        }
    }

    private Animal _editedAnimal = new();
    public Animal EditedAnimal
    {
        get => _editedAnimal;
        set => SetProperty(ref _editedAnimal, value);
    }

    public AnimalsPageViewModel(AnimalShelterDbContext dbContext)
    {
        _dbContext = dbContext;
        LoadAnimals();
        ClearForm();
    }

    private void LoadAnimals()
    {
        Animals.Clear();
        foreach (var animal in _dbContext.Animals.ToList())
        {
            Animals.Add(animal);
        }
    }

    public void AddAnimal()
    {
        if (string.IsNullOrWhiteSpace(EditedAnimal.Name)) return;

        _dbContext.Animals.Add(EditedAnimal);
        _dbContext.SaveChanges();
        LoadAnimals();
        ClearForm();
    }

    public void UpdateAnimal()
    {
        if (SelectedAnimal == null) return;

        var animal = _dbContext.Animals.Find(SelectedAnimal.Id);
        if (animal != null)
        {
            animal.Name = EditedAnimal.Name;
            animal.Species = EditedAnimal.Species;
            animal.Breed = EditedAnimal.Breed;
            animal.Age = EditedAnimal.Age;
            animal.Gender = EditedAnimal.Gender;
            animal.Color = EditedAnimal.Color;
            animal.Size = EditedAnimal.Size;
            animal.Microchip = EditedAnimal.Microchip;
            animal.Location = EditedAnimal.Location;
            animal.IsAdopted = EditedAnimal.IsAdopted;

            _dbContext.SaveChanges();
            LoadAnimals();
        }
    }

    public void DeleteAnimal()
    {
        if (SelectedAnimal == null)
            return;

        if (SelectedAnimal.IsAdopted == true)
        {
            return;
        }

        _dbContext.Animals.Remove(SelectedAnimal);
        _dbContext.SaveChanges();
        LoadAnimals();
        ClearForm();
    }


    public void ClearForm()
    {
        EditedAnimal = new Animal();
        SelectedAnimal = null;
    }
}
