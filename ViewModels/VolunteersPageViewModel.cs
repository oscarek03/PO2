using System.Collections.ObjectModel;
using AnimalShelter.Models;
using AnimalShelter.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AnimalShelter.ViewModels;

public partial class VolunteersPageViewModel : ViewModelBase
{
    private readonly AnimalShelterDbContext _dbContext;

    public ObservableCollection<Volunteer> Volunteers { get; set; } = new();

    private Volunteer? _selectedVolunteer;
    public Volunteer? SelectedVolunteer
    {
        get => _selectedVolunteer;
        set => SetProperty(ref _selectedVolunteer, value);
    }

    public VolunteersPageViewModel(AnimalShelterDbContext dbContext)
    {
        _dbContext = dbContext;
        LoadVolunteers();
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

    public void AddVolunteer(Volunteer newVolunteer)
    {
        _dbContext.Volunteers.Add(newVolunteer);
        _dbContext.SaveChanges();
        Volunteers.Add(newVolunteer);
    }

    public void UpdateVolunteer(Volunteer updatedVolunteer)
    {
        var volunteer = _dbContext.Volunteers.Find(updatedVolunteer.Id);
        if (volunteer != null)
        {
            _dbContext.Entry(volunteer).CurrentValues.SetValues(updatedVolunteer);
            _dbContext.SaveChanges();
            LoadVolunteers();
        }
    }

    public void DeleteVolunteer(Volunteer volunteerToDelete)
    {
        if (volunteerToDelete != null)
        {
            _dbContext.Volunteers.Remove(volunteerToDelete);
            _dbContext.SaveChanges();
            Volunteers.Remove(volunteerToDelete);
        }
    }
}