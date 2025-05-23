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

    public VolunteersPageViewModel(AnimalShelterDbContext dbContext)
    {
        _dbContext = dbContext;
        LoadVolunteers();
    }

    private void LoadVolunteers()
    {
        // Ensure DB is created
        _dbContext.Database.EnsureCreated();

        var volunteersFromDb = _dbContext.Volunteers.ToList();

        Volunteers.Clear();
        foreach (var animal in volunteersFromDb)
        {
            Volunteers.Add(animal);
        }
    }
}