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
    //pobieram aktualny datac context, zeby go zrzutowac na ViewModel (mam latwy dostep do metod ktore sa we viewmodel)
    private AdoptionsPageViewModel? ViewModel => DataContext as AdoptionsPageViewModel;
    
    //obsluguje rozne metody, ktore sa przypisane do przyciskow w widoku
    private void OnAdd(object? sender, RoutedEventArgs e) => ViewModel?.AddAdoption();
    private void OnUpdate(object? sender, RoutedEventArgs e) => ViewModel?.UpdateAdoption();
    private void OnDelete(object? sender, RoutedEventArgs e) => ViewModel?.DeleteAdoption();
    private void OnClear(object? sender, RoutedEventArgs e) => ViewModel?.ClearForm();
}