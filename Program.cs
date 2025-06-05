using Avalonia;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Data;
using AnimalShelter.ViewModels;

namespace AnimalShelter;

sealed class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        // Wczytanie konfiguracji (np. appsettings.json)
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        IConfiguration configuration = builder.Build();

        // Rejestracja usług w kontenerze DI
        var services = new ServiceCollection();

        // Baza danych
        services.AddDbContext<AnimalShelterDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        // ViewModele
        services.AddSingleton<MainViewModel>();
        services.AddTransient<AnimalsPageViewModel>();
        services.AddTransient<AdoptionsPageViewModel>();
        services.AddTransient<AddressesPageViewModel>();
        services.AddTransient<VolunteersPageViewModel>();

        // Budowanie kontenera
        var serviceProvider = services.BuildServiceProvider();

        // Start Avalonia z DI
        BuildAvaloniaApp(serviceProvider)
            .StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp(IServiceProvider serviceProvider)
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .AfterSetup(_ =>
            {
                App.ServiceProvider = serviceProvider;
            });
}