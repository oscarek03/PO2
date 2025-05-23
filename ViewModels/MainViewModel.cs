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
    [NotifyPropertyChangedFor(nameof(SettingsPageIsActive))]
    [NotifyPropertyChangedFor(nameof(SchedulePageIsActive))]
    [NotifyPropertyChangedFor(nameof(VolunteersPageIsActive))]
    [NotifyPropertyChangedFor(nameof(StatisticsPageIsActive))]
    private ViewModelBase _currentPage;

    public bool AnimalsPageIsActive => CurrentPage == _animalsPage;
    public bool AdoptionsPageIsActive => CurrentPage == _adoptionsPage;
    public bool SettingsPageIsActive => CurrentPage == _settingsPage;
    public bool SchedulePageIsActive => CurrentPage == _schedulePage;
    public bool VolunteersPageIsActive => CurrentPage == _volunteersPage;
    public bool StatisticsPageIsActive => CurrentPage == _statisticsPage;

    private readonly AnimalsPageViewModel _animalsPage;
    private readonly AdoptionsPageViewModel _adoptionsPage;
    private readonly SchedulePageViewModel _schedulePage;
    private readonly StatisticsPageViewModel _statisticsPage;
    private readonly SettingsPageViewModel _settingsPage;
    private readonly VolunteersPageViewModel _volunteersPage;

    public MainViewModel(
        AnimalsPageViewModel animalsPage,
        AdoptionsPageViewModel adoptionsPage,
        SchedulePageViewModel schedulePage,
        StatisticsPageViewModel statisticsPage,
        SettingsPageViewModel settingsPage,
        VolunteersPageViewModel volunteersPage)
    {
        _animalsPage = animalsPage;
        _adoptionsPage = adoptionsPage;
        _schedulePage = schedulePage;
        _statisticsPage = statisticsPage;
        _settingsPage = settingsPage;
        _volunteersPage = volunteersPage;

        _currentPage = _animalsPage;
    }

    [RelayCommand]
    private void GoToAnimals() => CurrentPage = _animalsPage;

    [RelayCommand]
    private void GoToAdoptions() => CurrentPage = _adoptionsPage;

    [RelayCommand]
    private void GoToSchedule() => CurrentPage = _schedulePage;

    [RelayCommand]
    private void GoToStatistics() => CurrentPage = _statisticsPage;

    [RelayCommand]
    private void GoToSettings() => CurrentPage = _settingsPage;

    [RelayCommand]
    private void GoToVolunteers() => CurrentPage = _volunteersPage;
}
