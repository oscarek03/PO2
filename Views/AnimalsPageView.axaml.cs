using Avalonia.Controls;
using Avalonia.Interactivity;
using AnimalShelter.Models;
using AnimalShelter.ViewModels;

namespace AnimalShelter.Views;

public partial class AnimalsPageView : UserControl
{
    public AnimalsPageView()
    {
        InitializeComponent();
    }

    private AnimalsPageViewModel? ViewModel => DataContext as AnimalsPageViewModel;

    private void OnAddAnimal(object? sender, RoutedEventArgs e)
    {
        var newAnimal = new Animal
        {
            Name = "Imię",
            Species = "Gatunek",
            Breed = "Rasa",
            Age = 1,
            Gender = "Płeć",
            Color = "Kolor",
            Size = "Rozmiar",
            Microchip = "000000",
            Location = "Boks",
            IsAdopted = false
        };

        ViewModel?.AddAnimal(newAnimal);
    }

    private void OnUpdateAnimal(object? sender, RoutedEventArgs e)
    {
        if (ViewModel?.SelectedAnimal != null)
        {
            ViewModel.UpdateAnimal(ViewModel.SelectedAnimal);
        }
    }

    private void OnDeleteAnimal(object? sender, RoutedEventArgs e)
    {
        if (ViewModel?.SelectedAnimal != null)
        {
            ViewModel.DeleteAnimal(ViewModel.SelectedAnimal);
        }
    }
}