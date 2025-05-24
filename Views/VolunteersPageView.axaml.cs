using Avalonia.Controls;
using Avalonia.Interactivity;
using AnimalShelter.Models;
using AnimalShelter.ViewModels;

namespace AnimalShelter.Views;

public partial class VolunteersPageView : UserControl
{
    public VolunteersPageView()
    {
        InitializeComponent();
    }

    private VolunteersPageViewModel? ViewModel => DataContext as VolunteersPageViewModel;

    private void OnAddVolunteer(object? sender, RoutedEventArgs e)
    {
        var newVolunteer = new Volunteer
        {
            FullName = "New Volunteer", 
            Email = "new.volunteer@example.com",
            PhoneNumber = "000-000-0000",
            AdditionalNotes = "",
            AddressId = 1, 
        };

        ViewModel?.AddVolunteer(newVolunteer);
    }

    private void OnUpdateVolunteer(object? sender, RoutedEventArgs e)
    {
        if (ViewModel?.SelectedVolunteer != null)
        {
            ViewModel.UpdateVolunteer(ViewModel.SelectedVolunteer);
        }
    }

    private void OnDeleteVolunteer(object? sender, RoutedEventArgs e)
    {
        if (ViewModel?.SelectedVolunteer != null)
        {
            ViewModel.DeleteVolunteer(ViewModel.SelectedVolunteer);
        }
    }
}