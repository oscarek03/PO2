using AnimalShelter.Models;
using AnimalShelter.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AnimalShelter.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private const string buttonActiveClass = "active";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(AnimalsPageIsActive))]
    [NotifyPropertyChangedFor(nameof(AdoptionsPageIsActive))]
    [NotifyPropertyChangedFor(nameof(AddressesPageIsActive))]
    [NotifyPropertyChangedFor(nameof(VolunteersPageIsActive))]
    private ViewModelBase _currentPage;

    public bool AnimalsPageIsActive => CurrentPage == _animalsPage;
    public bool AdoptionsPageIsActive => CurrentPage == _adoptionsPage;
    public bool AddressesPageIsActive => CurrentPage == _addressesPage;
    public bool VolunteersPageIsActive => CurrentPage == _volunteersPage;

    private readonly AnimalsPageViewModel _animalsPage;
    private readonly AdoptionsPageViewModel _adoptionsPage;
    private readonly AddressesPageViewModel _addressesPage;
    private readonly VolunteersPageViewModel _volunteersPage;

    public MainViewModel(
        AnimalsPageViewModel animalsPage,
        AdoptionsPageViewModel adoptionsPage,
        AddressesPageViewModel addressesPage,
        VolunteersPageViewModel volunteersPage)
    {
        _animalsPage = animalsPage;
        _adoptionsPage = adoptionsPage;
        _addressesPage = addressesPage;
        _volunteersPage = volunteersPage;

        _currentPage = _animalsPage;
    }

    [RelayCommand]
    private void GoToAnimals() => CurrentPage = _animalsPage;

    [RelayCommand]
    private void GoToAdoptions() => CurrentPage = _adoptionsPage;

    [RelayCommand]
    private void GoToAddresses() => CurrentPage = _addressesPage;

    [RelayCommand]
    private void GoToVolunteers() => CurrentPage = _volunteersPage;
}
