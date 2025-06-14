﻿using System.Collections.ObjectModel;
using AnimalShelter.Models;
using AnimalShelter.Data;
using System.Linq;
using System.Text.RegularExpressions;

namespace AnimalShelter.ViewModels;

public partial class AddressesPageViewModel : ViewModelBase
{
    private readonly AnimalShelterDbContext _dbContext;

    public ObservableCollection<Address> Addresses { get; set; } = new();

    private Address? _selectedAddress;
    public Address? SelectedAddress
    {
        get => _selectedAddress;
        set 
        { 
            SetProperty(ref _selectedAddress, value);
            if (value != null)
            {
                // kopiuje dane do formularza
                EditedAddress = new Address
                {
                    Id = value.Id,
                    StreetAddress = value.StreetAddress,
                    City = value.City,
                    PostalCode = value.PostalCode,
                    Country = value.Country
                };
            }
        }
    }

    private Address _editedAddress = new();
    public Address EditedAddress
    {
        get => _editedAddress;
        set => SetProperty(ref _editedAddress, value);
    }

    public AddressesPageViewModel(AnimalShelterDbContext dbContext)
    {
        _dbContext = dbContext;
        LoadAddresses();
        ClearForm();
    }

    // zaktualizowanie listy adresow z bazy
    private void LoadAddresses()
    {
        Addresses.Clear();
        foreach (var address in _dbContext.Addresses.ToList())
        {
            Addresses.Add(address);
        }
    }

    private string _alertText = string.Empty;
    public string AlertText
    {
        get => _alertText;
        set
        {
            _alertText = value;
            OnPropertyChanged(nameof(AlertText));
        }
    }
    
    // dodanie nowego adresu do bazy
    public void AddAddress()
    {
        bool alreadyExists = _dbContext.Addresses.Any(a => a.StreetAddress == EditedAddress.StreetAddress);


        if (alreadyExists)
        {
            AlertText = "You already have an address with this street address.";
            return;
        } 

        // walidacja dla kodu pocztowego (12-345)
        if (string.IsNullOrWhiteSpace(EditedAddress.PostalCode) 
            || !Regex.IsMatch(EditedAddress.PostalCode, @"^\d{2}-\d{3}$"))
        {
            AlertText = "Please enter a valid postal code.";
            return;
        }

        // walidacja dla miasta (po prostu bez cyfr i znakow specjalnych)
        if (string.IsNullOrWhiteSpace(EditedAddress.City)
            || !Regex.IsMatch(EditedAddress.City, @"^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ\s\-]+$") )
        {
            AlertText = "Please enter a valid city.";
            return;
        }

        // walidacja dla kraju (bez cyfr i znakow specjalnych)
        if (string.IsNullOrWhiteSpace(EditedAddress.Country) 
            || !Regex.IsMatch(EditedAddress.Country, @"^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ\s\-]+$"))
        {
            AlertText = "Please enter a valid country.";
            return;
        }

        _dbContext.Addresses.Add(EditedAddress);
        _dbContext.SaveChanges();
        LoadAddresses();
        ClearForm();
    }

    // aktualizacja wybranego adresu z datagrid w bazie
    public void UpdateAddress()
    {
        if (SelectedAddress == null) return;

        // walidacja dla kodu pocztowego (12-345)
        if (string.IsNullOrWhiteSpace(EditedAddress.PostalCode)
            || !Regex.IsMatch(EditedAddress.PostalCode, @"^\d{2}-\d{3}$"))
        {
            AlertText = "Please enter a valid postal code.";
            return;
        }

        // walidacja dla miasta (po prostu bez cyfr i znakow specjalnych)
        if (string.IsNullOrWhiteSpace(EditedAddress.City)
            || !Regex.IsMatch(EditedAddress.City, @"^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ\s\-]+$"))
        {
            AlertText = "Please enter a valid city.";
            return;
        }

        // walidacja dla kraju (bez cyfr i znakow specjalnych)
        if (string.IsNullOrWhiteSpace(EditedAddress.Country)
            || !Regex.IsMatch(EditedAddress.Country, @"^[A-Za-zżźćńółęąśŻŹĆĄŚĘŁÓŃ\s\-]+$"))
        {
            AlertText = "Please enter a valid country.";
            return;
        }

        var address = _dbContext.Addresses.Find(SelectedAddress.Id);
        if (address != null)
        {
            address.StreetAddress = EditedAddress.StreetAddress;
            address.City = EditedAddress.City;
            address.PostalCode = EditedAddress.PostalCode;
            address.Country = EditedAddress.Country;

            _dbContext.SaveChanges();
            // aktualizuje mi datagrid w momencie aktualizacji zwierza (inaczej by go zaktualizowalo, i musialbym zmienic zakladke)
            _dbContext.Entry(address).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            LoadAddresses();
        }
    }

    // usuwa wybrany adres z bazy, po czym aktualizuje liste
    public void DeleteAddress()
    {
        if (SelectedAddress == null)
            return;

        // sprawdza czy wybrany adres nie jest czasem uzyty w adopcjach
        var hasAdoptions = _dbContext.Adoptions?.Any(a => a.AddressId == SelectedAddress.Id) ?? false;
        if (hasAdoptions)
        {
            return;
        }

        // sprawdza czy wybrany adres nie jest czasem uzyty przez wolontariuszy
        var hasVolunteers = _dbContext.Volunteers?.Any(v => v.AddressId == SelectedAddress.Id) ?? false;
        if (hasVolunteers)
        {
            return;
        }

        _dbContext.Addresses.Remove(SelectedAddress);
        _dbContext.SaveChanges();
        LoadAddresses();
        ClearForm();
    }

    // czysci formularz z danych zeby nie robic tego recznie
    public void ClearForm()
    {
        EditedAddress = new Address();
        SelectedAddress = null;
    }
}
