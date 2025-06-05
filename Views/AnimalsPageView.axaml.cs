using Avalonia.Controls;
using Avalonia.Interactivity;
using AnimalShelter.ViewModels;

namespace AnimalShelter.Views;

public partial class AnimalsPageView : UserControl
{
    public AnimalsPageView()
    {
        InitializeComponent();
    }

    //pobieram aktualny datac context, zeby go zrzutowac na ViewModel (mam latwy dostep do metod ktore sa we viewmodel)
    private AnimalsPageViewModel? ViewModel => DataContext as AnimalsPageViewModel;

    private void OnAdd(object? sender, RoutedEventArgs e) => ViewModel?.AddAnimal();
    private void OnUpdate(object? sender, RoutedEventArgs e) => ViewModel?.UpdateAnimal();
    private void OnDelete(object? sender, RoutedEventArgs e) => ViewModel?.DeleteAnimal();
    private void OnClear(object? sender, RoutedEventArgs e) => ViewModel?.ClearForm();
}