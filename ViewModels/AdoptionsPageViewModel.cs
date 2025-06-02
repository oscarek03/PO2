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

    private Adoption? _selectedAdoption;
    public Adoption? SelectedAdoption
    {
        get => _selectedAdoption;
        set 
        { 
            SetProperty(ref _selectedAdoption, value);
            if (value != null)
            {
                EditedAdoption = new Adoption
                {
                    Id = value.Id,
                    FullName = value.FullName,
                    Email = value.Email,
                    PhoneNumber = value.PhoneNumber,
                    AnimalId = value.AnimalId,
                    AddressId = value.AddressId
                };
                
                // Znajdź zwierzę (także wśród adoptowanych)
                SelectedAnimal = AvailableAnimals.FirstOrDefault(a => a.Id == value.AnimalId) 
                               ?? _dbContext.Animals.Find(value.AnimalId);
                
                SelectedAddress = ExistingAddresses.FirstOrDefault(a => a.Id == value.AddressId);
            }
        }
    }

    private Adoption _editedAdoption = new();
    public Adoption EditedAdoption
    {
        get => _editedAdoption;
        set => SetProperty(ref _editedAdoption, value);
    }

    private Animal? _selectedAnimal;
    public Animal? SelectedAnimal
    {
        get => _selectedAnimal;
        set => SetProperty(ref _selectedAnimal, value);
    }

    private Address? _selectedAddress;
    public Address? SelectedAddress
    {
        get => _selectedAddress;
        set => SetProperty(ref _selectedAddress, value);
    }

    public AdoptionsPageViewModel(AnimalShelterDbContext dbContext)
    {
        _dbContext = dbContext;
        LoadData();
    }

    private void LoadData()
    {
        Adoptions.Clear();
        AvailableAnimals.Clear();
        ExistingAddresses.Clear();

        foreach (var adoption in _dbContext.Adoptions.Include(a => a.Animal).Include(a => a.Address).ToList())
            Adoptions.Add(adoption);

        foreach (var animal in _dbContext.Animals.Where(a => a.IsAdopted != true).ToList())
            AvailableAnimals.Add(animal);

        foreach (var address in _dbContext.Addresses.ToList())
            ExistingAddresses.Add(address);
    }

    public void AddAdoption()
    {
        if (SelectedAnimal == null || string.IsNullOrWhiteSpace(EditedAdoption.FullName)) return;

        var newAdoption = new Adoption
        {
            FullName = EditedAdoption.FullName,
            Email = EditedAdoption.Email,
            PhoneNumber = EditedAdoption.PhoneNumber,
            AnimalId = SelectedAnimal.Id,
            AddressId = SelectedAddress?.Id ?? 1,
            AdoptionDate = DateTime.Now
        };

        _dbContext.Adoptions.Add(newAdoption);

        var animal = _dbContext.Animals.Find(SelectedAnimal.Id);
        if (animal != null)
        {
            animal.IsAdopted = true;
            _dbContext.Animals.Update(animal);
        }

        _dbContext.SaveChanges();
        LoadData();
        ClearForm();
    }


    public void UpdateAdoption()
    {
        if (SelectedAdoption == null) return;

        var adoption = _dbContext.Adoptions.Find(SelectedAdoption.Id);
        if (adoption != null)
        {
            adoption.FullName = EditedAdoption.FullName;
            adoption.Email = EditedAdoption.Email;
            adoption.PhoneNumber = EditedAdoption.PhoneNumber;

            if (SelectedAnimal != null)
                adoption.AnimalId = SelectedAnimal.Id;

            if (SelectedAddress != null)
                adoption.AddressId = SelectedAddress.Id;

            _dbContext.SaveChanges();
            LoadData();
        }
    }

    public void DeleteAdoption()
    {
        if (SelectedAdoption == null) return;

        var adoption = _dbContext.Adoptions.Find(SelectedAdoption.Id);
        if (adoption != null)
        {
            var animal = _dbContext.Animals.Find(adoption.AnimalId);
            if (animal != null)
            {
                animal.IsAdopted = false;
                _dbContext.Animals.Update(animal);
            }

            _dbContext.Adoptions.Remove(adoption);
            _dbContext.SaveChanges();
            LoadData();
            ClearForm();
        }
    }
    public void ClearForm()
    {
        EditedAdoption = new Adoption();
        SelectedAnimal = null;
        SelectedAddress = null;
        SelectedAdoption = null;
    }
}
