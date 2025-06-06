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
                // kopiuje dane do formularza
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

    // laduje wszystkie aktualne zwierzeta (z bazy) do kolekcji

    private void LoadAnimals()
    {
        Animals.Clear();
        foreach (var animal in _dbContext.Animals.ToList())
        {
            Animals.Add(animal);
        }
    }

    // dodaje nowe zwierze do bazy (z formularza, po czym aktualizuje liste)
    public void AddAnimal()
    {
        if (string.IsNullOrWhiteSpace(EditedAnimal.Name) ||
            string.IsNullOrWhiteSpace(EditedAnimal.Species) ||
            string.IsNullOrWhiteSpace(EditedAnimal.Breed) ||
            EditedAnimal.Age == null ||
            string.IsNullOrWhiteSpace(EditedAnimal.Gender) ||
            string.IsNullOrWhiteSpace(EditedAnimal.Color) ||
            string.IsNullOrWhiteSpace(EditedAnimal.Size) ||
            string.IsNullOrWhiteSpace(EditedAnimal.Microchip) ||
            string.IsNullOrWhiteSpace(EditedAnimal.Location)) 
            return;


        _dbContext.Animals.Add(EditedAnimal);
        _dbContext.SaveChanges();
        LoadAnimals();
        ClearForm();
    }

    // aktualizuje wybrane zwierze  (z formularza, po czym aktualizuje liste)
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
            // aktualizuje mi datagrid w momencie aktualizacji zwierza (inaczej by go zaktualizowalo, i musialbym zmienic zakladke)
            _dbContext.Entry(animal).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            LoadAnimals();
        }
    }

    // usuwa wybrane zwierze (z formularza, po czym aktualizuje liste)
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

    // czysci formularz z danych zeby nie robic tego recznie
    public void ClearForm()
    {
        EditedAnimal = new Animal();
        SelectedAnimal = null;
    }
}
