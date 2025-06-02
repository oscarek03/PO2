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

    private void OnAdd(object? sender, RoutedEventArgs e) => ViewModel?.AddAdoption();
    private void OnUpdate(object? sender, RoutedEventArgs e) => ViewModel?.UpdateAdoption();
    private void OnDelete(object? sender, RoutedEventArgs e) => ViewModel?.DeleteAdoption();
    private void OnClear(object? sender, RoutedEventArgs e) => ViewModel?.ClearForm();
}