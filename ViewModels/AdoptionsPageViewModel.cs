using System.Collections.ObjectModel;
using AnimalShelter.Models;
using AnimalShelter.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AnimalShelter.ViewModels;

public partial class AdoptionsPageViewModel : ViewModelBase
{
    private readonly AnimalShelterDbContext _dbContext;

    public ObservableCollection<Adoption> Adoptions { get; set; } = new();

    public AdoptionsPageViewModel(AnimalShelterDbContext dbContext)
    {
        _dbContext = dbContext;
        LoadAdoptions();
    }

    private void LoadAdoptions()
    {
        // Ensure DB is created
        _dbContext.Database.EnsureCreated();

        var adoptionsFromDb = _dbContext.Adoptions.ToList();

        Adoptions.Clear();
        foreach (var animal in adoptionsFromDb)
        {
            Adoptions.Add(animal);
        }
    }
}