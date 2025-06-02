using Avalonia.Controls;
using Avalonia.Interactivity;
using AnimalShelter.ViewModels;

namespace AnimalShelter.Views;

public partial class VolunteersPageView : UserControl
{
    public VolunteersPageView()
    {
        InitializeComponent();
    }

    private VolunteersPageViewModel? ViewModel => DataContext as VolunteersPageViewModel;

    private void OnAddVolunteer(object? sender, RoutedEventArgs e) => ViewModel?.AddVolunteer();
    private void OnUpdateVolunteer(object? sender, RoutedEventArgs e) => ViewModel?.UpdateVolunteer();
    private void OnDeleteVolunteer(object? sender, RoutedEventArgs e) => ViewModel?.DeleteVolunteer();
    private void OnClearForm(object? sender, RoutedEventArgs e) => ViewModel?.ClearForm();
}