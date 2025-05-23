using Avalonia.Controls;
using Avalonia.Interactivity;
using AnimalShelter.ViewModels;

namespace AnimalShelter.Views;

public partial class AdoptionsPageView : UserControl
{
    public AdoptionsPageView()
    {
        InitializeComponent();
    }

    private AdoptionsPageViewModel? ViewModel => DataContext as AdoptionsPageViewModel;

    private void OnDeleteAdoption(object? sender, RoutedEventArgs e)
    {
        ViewModel?.DeleteAdoption();
    }

    private void OnAddAdoption(object? sender, RoutedEventArgs e)
    {
        ViewModel?.AddAdoption();
    }
}