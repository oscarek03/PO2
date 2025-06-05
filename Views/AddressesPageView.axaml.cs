using Avalonia.Controls;
using Avalonia.Interactivity;
using AnimalShelter.ViewModels;

namespace AnimalShelter.Views;

public partial class AddressesPageView : UserControl
{
    public AddressesPageView()
    {
        InitializeComponent();
    }
    
    //pobieram aktualny data  context, zeby go zrzutowac na ViewModel (mam latwy dostep do metod ktore sa we viewmodel)
    private AddressesPageViewModel? ViewModel => DataContext as AddressesPageViewModel;

    //obsluguje rozne metody, ktore sa przypisane do przyciskow w widoku
    private void OnAdd(object? sender, RoutedEventArgs e) => ViewModel?.AddAddress();
    private void OnUpdate(object? sender, RoutedEventArgs e) => ViewModel?.UpdateAddress();
    private void OnDelete(object? sender, RoutedEventArgs e) => ViewModel?.DeleteAddress();
    private void OnClear(object? sender, RoutedEventArgs e) => ViewModel?.ClearForm();
}