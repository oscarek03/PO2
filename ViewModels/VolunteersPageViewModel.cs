using System.Collections.ObjectModel;
using AnimalShelter.Models;
using AnimalShelter.Data;
using System.Linq;

namespace AnimalShelter.ViewModels;

public partial class VolunteersPageViewModel : ViewModelBase
{
    private readonly AnimalShelterDbContext _dbContext;

    public ObservableCollection<Volunteer> Volunteers { get; set; } = new();
    public ObservableCollection<Address> Addresses { get; set; } = new();

    private Volunteer? _selectedVolunteer;
    public Volunteer? SelectedVolunteer
    {
        get => _selectedVolunteer;
        set
        {
            SetProperty(ref _selectedVolunteer, value);
            if (value != null)
            {
                EditedVolunteer = new Volunteer
                {
                    Id = value.Id,
                    FullName = value.FullName,
                    Email = value.Email,
                    PhoneNumber = value.PhoneNumber,
                    AdditionalNotes = value.AdditionalNotes,
                    AddressId = value.AddressId,
                    Address = value.Address
                };
                SelectedAddress = Addresses.FirstOrDefault(a => a.Id == value.AddressId);
            }
        }
    }

    private Volunteer _editedVolunteer = new();
    public Volunteer EditedVolunteer
    {
        get => _editedVolunteer;
        set => SetProperty(ref _editedVolunteer, value);
    }

    private Address? _selectedAddress;
    public Address? SelectedAddress
    {
        get => _selectedAddress;
        set
        {
            SetProperty(ref _selectedAddress, value);
            if (value != null)
                EditedVolunteer.AddressId = value.Id;
        }
    }

    public VolunteersPageViewModel(AnimalShelterDbContext dbContext)
    {
        _dbContext = dbContext;
        LoadAddresses();
        LoadVolunteers();
        ClearForm();
    }

    private void LoadVolunteers()
    {
        _dbContext.Database.EnsureCreated();
        Volunteers.Clear();
        foreach (var volunteer in _dbContext.Volunteers.ToList())
        {
            Volunteers.Add(volunteer);
        }
    }

    private void LoadAddresses()
    {
        Addresses.Clear();
        foreach (var address in _dbContext.Addresses.ToList())
        {
            Addresses.Add(address);
        }
    }

    public void AddVolunteer()
    {
        if (string.IsNullOrWhiteSpace(EditedVolunteer.FullName) || SelectedAddress == null) return;

        var newVolunteer = new Volunteer
        {
            FullName = EditedVolunteer.FullName,
            Email = EditedVolunteer.Email,
            PhoneNumber = EditedVolunteer.PhoneNumber,
            AdditionalNotes = EditedVolunteer.AdditionalNotes,
            AddressId = SelectedAddress.Id
        };

        _dbContext.Volunteers.Add(newVolunteer);
        _dbContext.SaveChanges();
        LoadVolunteers();
        ClearForm();
    }

    public void UpdateVolunteer()
    {
        if (SelectedVolunteer == null || SelectedAddress == null) return;

        var volunteer = _dbContext.Volunteers.Find(SelectedVolunteer.Id);
        if (volunteer != null)
        {
            volunteer.FullName = EditedVolunteer.FullName;
            volunteer.Email = EditedVolunteer.Email;
            volunteer.PhoneNumber = EditedVolunteer.PhoneNumber;
            volunteer.AdditionalNotes = EditedVolunteer.AdditionalNotes;
            volunteer.AddressId = SelectedAddress.Id;

            _dbContext.SaveChanges();
            LoadVolunteers();
            ClearForm();
        }
    }

    public void DeleteVolunteer()
    {
        if (SelectedVolunteer == null) return;

        var volunteer = _dbContext.Volunteers.Find(SelectedVolunteer.Id);
        if (volunteer != null)
        {
            _dbContext.Volunteers.Remove(volunteer);
            _dbContext.SaveChanges();
            LoadVolunteers();
            ClearForm();
        }
    }

    public void ClearForm()
    {
        EditedVolunteer = new Volunteer();
        SelectedVolunteer = null;
        SelectedAddress = null;
    }
}
