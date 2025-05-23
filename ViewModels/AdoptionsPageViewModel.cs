using System.Collections.ObjectModel;
using AnimalShelter.Models;
using AnimalShelter.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace AnimalShelter.ViewModels;

public partial class AdoptionsPageViewModel : ViewModelBase
{
    private readonly AnimalShelterDbContext _dbContext;

    public ObservableCollection<Adoption> Adoptions { get; set; } = new();
    public ObservableCollection<Animal> AvailableAnimals { get; set; } = new();
    public ObservableCollection<Address> ExistingAddresses { get; set; } = new();

    public Adoption? NewAdoption { get; set; } = new();
    public Animal? SelectedAnimal { get; set; }
    public Address? SelectedAddress { get; set; }
    public Address NewAddress { get; set; } = new();

    private Adoption? _selectedAdoption;
    public Adoption? SelectedAdoption
    {
        get => _selectedAdoption;
        set => SetProperty(ref _selectedAdoption, value);
    }

    private bool _isNewAddressVisible;
    public bool IsNewAddressVisible
    {
        get => _isNewAddressVisible;
        set => SetProperty(ref _isNewAddressVisible, value);
    }

    public AdoptionsPageViewModel(AnimalShelterDbContext dbContext)
    {
        _dbContext = dbContext;
        LoadAdoptions();
        LoadAvailableAnimals();
        LoadExistingAddresses();
    }

    private void LoadAdoptions()
    {
        _dbContext.Database.EnsureCreated();
        Adoptions.Clear();
        var list = _dbContext.Adoptions
            .Include(a => a.Animal)
            .Include(a => a.Address)
            .ToList();

        foreach (var adoption in list)
        {
            Adoptions.Add(adoption);
        }
    }

    private void LoadAvailableAnimals()
    {
        AvailableAnimals.Clear();
        var animals = _dbContext.Animals
            .Where(a => a.IsAdopted == false || a.IsAdopted == null)
            .ToList();

        foreach (var a in animals)
        {
            AvailableAnimals.Add(a);
        }
    }

    private void LoadExistingAddresses()
    {
        ExistingAddresses.Clear();
        var addresses = _dbContext.Addresses.ToList();
        foreach (var addr in addresses)
        {
            ExistingAddresses.Add(addr);
        }
    }

    public void AddAdoption()
    {
        if (SelectedAnimal == null || NewAdoption == null)
            return;

        NewAdoption.AnimalId = SelectedAnimal.Id;
        NewAdoption.AdoptionDate = DateTime.UtcNow;

        if (IsNewAddressVisible)
        {
            _dbContext.Addresses.Add(NewAddress);
            _dbContext.SaveChanges();
            NewAdoption.AddressId = NewAddress.Id;
        }
        else if (SelectedAddress != null)
        {
            NewAdoption.AddressId = SelectedAddress.Id;
        }
        else
        {
            return; // brak adresu
        }

        _dbContext.Adoptions.Add(NewAdoption);

        SelectedAnimal.IsAdopted = true;
        _dbContext.Animals.Update(SelectedAnimal);

        _dbContext.SaveChanges();

        // Odświeżenie danych
        LoadAdoptions();
        LoadAvailableAnimals();
        LoadExistingAddresses();

        // Reset formularza
        NewAdoption = new Adoption();
        NewAddress = new Address();
        SelectedAddress = null;
        SelectedAnimal = null;
        IsNewAddressVisible = false;
    }

    public void DeleteAdoption()
    {
        if (SelectedAdoption == null)
            return;

        var adoption = _dbContext.Adoptions
            .FirstOrDefault(a => a.Id == SelectedAdoption.Id);

        if (adoption != null)
        {
            var animal = _dbContext.Animals.FirstOrDefault(a => a.Id == adoption.AnimalId);
            if (animal != null)
            {
                animal.IsAdopted = false;
                _dbContext.Animals.Update(animal);
            }

            _dbContext.Adoptions.Remove(adoption);
            _dbContext.SaveChanges();
        }

        LoadAdoptions();
        LoadAvailableAnimals();
        SelectedAdoption = null;
    }
}
