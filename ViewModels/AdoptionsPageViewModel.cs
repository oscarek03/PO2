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
    
    // przechowywanie wybranej adopcji + od razu wszystkie (dane dot. zwierzecia i adresu tez!) przenosi do formularza
    public Adoption? SelectedAdoption
    {
        get => _selectedAdoption;
        set 
        { 
            SetProperty(ref _selectedAdoption, value);
            if (value != null)
            {
                // kopiowanie danych do formularza
                EditedAdoption = new Adoption
                {
                    Id = value.Id,
                    FullName = value.FullName,
                    Email = value.Email,
                    PhoneNumber = value.PhoneNumber,
                    AnimalId = value.AnimalId,
                    AddressId = value.AddressId
                };
                
                // ustawia wybrane zwierze i adres (po prostu szuka wybranego zwierza/adres po ID w bazie)
                SelectedAnimal = AvailableAnimals.FirstOrDefault(a => a.Id == value.AnimalId) 
                               ?? _dbContext.Animals.Find(value.AnimalId);
                
                SelectedAddress = ExistingAddresses.FirstOrDefault(a => a.Id == value.AddressId);
            }
        }
    }

    private Adoption _editedAdoption = new();
    // przychowywuje dane adopcji do edycji/dodania
    public Adoption EditedAdoption
    {
        get => _editedAdoption;
        set => SetProperty(ref _editedAdoption, value);
    }
    
    private Animal? _selectedAnimal;
    // przechowywanie wybranego zwierza (ktory bedzie przypisany do adopcji)
    public Animal? SelectedAnimal
    {
        get => _selectedAnimal;
        set => SetProperty(ref _selectedAnimal, value);
    }

    private Address? _selectedAddress;
    
    // przechowywanie wybranego adresu (ktory bedzie przypisany do adopcji)
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

    // laduje wszystkie adopcje, zwierzeta do adopcji i adresy (do swoich list)
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

// dodaje nowa adopcje do bazy (dane bierze z formularza ofc), oznacza flage adopcji na true i aktualizuje liste
    public void AddAdoption()
    {
        if (SelectedAnimal == null || SelectedAddress == null || string.IsNullOrWhiteSpace(EditedAdoption.FullName))
            return;

        // sprawdzenie czy dany pies juz nie jest adoptowany
        var animal = _dbContext.Animals.Find(SelectedAnimal.Id);
        if (animal == null || animal.IsAdopted == true)
            return;

        var newAdoption = new Adoption
        {
            FullName = EditedAdoption.FullName,
            Email = EditedAdoption.Email,
            PhoneNumber = EditedAdoption.PhoneNumber,
            AnimalId = SelectedAnimal.Id,
            AddressId = SelectedAddress.Id,
            AdoptionDate = DateTime.Now
        };

        _dbContext.Adoptions.Add(newAdoption);

        animal.IsAdopted = true;
        _dbContext.Animals.Update(animal);

        _dbContext.SaveChanges();
        LoadData();
        ClearForm();
    }


    // aktualizuje wybrana adopcje na podstawie nowych danych z formularza
    public void UpdateAdoption()
    {
        if (SelectedAdoption == null) return;

        var adoption = _dbContext.Adoptions.Find(SelectedAdoption.Id);
        if (adoption != null)
        {
            // zapamietuje id starego zwierzeaka
            int oldAnimalId = adoption.AnimalId;

            adoption.FullName = EditedAdoption.FullName;
            adoption.Email = EditedAdoption.Email;
            adoption.PhoneNumber = EditedAdoption.PhoneNumber;

            if (SelectedAnimal != null)
                adoption.AnimalId = SelectedAnimal.Id;

            if (SelectedAddress != null)
                adoption.AddressId = SelectedAddress.Id;

            // jesli zwierze sie zmienilo podczas adopcji, to flaga isAdopted sie zmienia (stare dostae false, a nowe zwierze true)
            if (SelectedAnimal != null && oldAnimalId != SelectedAnimal.Id)
            {
                var oldAnimal = _dbContext.Animals.Find(oldAnimalId);
                if (oldAnimal != null)
                {
                    oldAnimal.IsAdopted = false;
                    _dbContext.Animals.Update(oldAnimal);
                }
                var newAnimal = _dbContext.Animals.Find(SelectedAnimal.Id);
                if (newAnimal != null)
                {
                    newAnimal.IsAdopted = true;
                    _dbContext.Animals.Update(newAnimal);
                }
            }

            _dbContext.SaveChanges();
            LoadData();
        }
    }


    // usuwa wybrana adopcje z bazy, ustawia flage adopcji na false dla wybranego zwierza i aktualizuje liste
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
    // czysci formularz z danych zeby nie robic tego recznie
    public void ClearForm()
    {
        EditedAdoption = new Adoption();
        SelectedAnimal = null;
        SelectedAddress = null;
        SelectedAdoption = null;
    }
}
