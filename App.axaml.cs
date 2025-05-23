using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using AnimalShelter.ViewModels;
using AnimalShelter.Views;
using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace AnimalShelter;

public partial class App : Application
{
    // Dodane: dostęp do ServiceProvider
    public static IServiceProvider? ServiceProvider { get; set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        DataTemplates.Add(new ViewLocator());
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Unikamy podwójnej walidacji
            DisableAvaloniaDataAnnotationValidation();

            // Użycie DI do utworzenia MainViewModel
            var mainViewModel = ServiceProvider!.GetRequiredService<MainViewModel>();

            desktop.MainWindow = new MainView
            {
                DataContext = mainViewModel
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}