# Animal Shelter

**Animal Shelter** to nowoczesna aplikacja napisana w .NET 9 i Avalonia, której celem jest wspieranie codziennej pracy schroniska dla zwierząt. Projekt stawia na przejrzystość, wygodę obsługi oraz wieloplatformowość.

---

## Spis treści

- [Opis projektu](#opis-projektu)
- [Technologie](#technologie)
- [Architektura](#architektura)
- [Funkcjonalności](#funkcjonalności)
- [Struktura katalogów](#struktura-katalogów)
- [Uruchamianie](#uruchamianie)
- [Autor](#autor)

---

## Opis projektu

Aplikacja umożliwia kompleksowe zarządzanie schroniskiem, w tym bazą zwierząt, wolontariuszy, adresów oraz procesem adopcji. Zaawansowana warstwa prezentacji i obsługi danych pozwala na łatwe wprowadzanie, przeglądanie i edycję informacji, zapewniając intuicyjną obsługę nawet mniej technicznym użytkownikom.

---

## Technologie

- **.NET 9**
- **C# 13.0**
- **Avalonia UI**
- Baza SQLite (`animalshelter.db`)

---

## Architektura

Projekt oparty jest o wzorzec MVVM (Model-View-ViewModel):

- **Models** — definicje danych: zwierzęta, wolontariusze, adopcje, adresy.
- **ViewModels** — logika prezentacji i komunikacja pomiędzy danymi a widokami.
- **Views** — nowoczesny, czytelny interfejs użytkownika tworzony przy użyciu Avalonia XAML.

Całość obsługuje bazę lokalną, ale z łatwością może zostać rozszerzona o zewnętrzne źródła danych.

---

## Funkcjonalności

- Przegląd i edycja statusu zwierząt w schronisku.
- Zarządzanie wolontariuszami i ich danymi kontaktowymi.
- Rejestracja i weryfikacja adopcji.
- Obsługa adresów powiązanych z użytkownikami/adopcją.
- Praca wielookienkowa oraz obsługa wielu widoków jednocześnie.
- Nowoczesny, intuicyjny interfejs.
- Prosta konfiguracja i możliwość rozbudowy.

---

## Struktura katalogów

```
├── Models           # Modele danych (Animal, Volunteer, Adoption, Address)
├── ViewModels       # Logika widoków oraz obsługa interakcji
├── Views            # XAML i code-behind dla widoków (np. AnimalsPageView, VolunteersPageView)
├── Data             # Warstwa dostępu do danych/baza/ew. repozytoria
├── Assets           # Zasoby graficzne, ikony (jeśli używane)
├── Styles           # Pliki stylów dla aplikacji Avalonia
├── Conventers       # Konwertery danych do widoków
├── Migrations       # Pliki migracji bazy danych (jeśli używane)
├── animalshelter.db # Lokalna baza SQLite
├── appsettings.json # Konfiguracja aplikacji
└── ...              # Pozostałe pliki konfiguracyjne
```

---

## Uruchamianie

1. **Wymagania:**  
   - .NET 9 SDK
   - System Windows, Linux lub macOS

2. **Budowa i uruchomienie:**  
   W katalogu głównym projektu wykonaj polecenie:

   ```bash
   dotnet run
   ```

   lub uruchom projekt bezpośrednio z poziomu IDE (np. JetBrains Rider, Visual Studio).

---

## Autor

Oscar Borowiec

---
