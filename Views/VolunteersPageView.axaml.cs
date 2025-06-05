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

    //pobieram aktualny datac context, zeby go zrzutowac na ViewModel (mam latwy dostep do metod ktore sa we viewmodel)
    private VolunteersPageViewModel? ViewModel => DataContext as VolunteersPageViewModel;

    //obsluguje rozne metody, ktore sa przypisane do przyciskow w widoku
    private void OnAddVolunteer(object? sender, RoutedEventArgs e) => ViewModel?.AddVolunteer();
    private void OnUpdateVolunteer(object? sender, RoutedEventArgs e) => ViewModel?.UpdateVolunteer();
    private void OnDeleteVolunteer(object? sender, RoutedEventArgs e) => ViewModel?.DeleteVolunteer();
    private void OnClearForm(object? sender, RoutedEventArgs e) => ViewModel?.ClearForm();
}