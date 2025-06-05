namespace AnimalShelter.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class Adoption
{
    public int Id { get; set; }
    public int AnimalId { get; set; }
    
    [MaxLength(100)]
    public string? FullName { get; set; }
    
    [MaxLength(150)]
    public string? Email { get; set; }
    
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }
    
    public DateTime? AdoptionDate { get; set; }
    public int AddressId { get; set; }
    
    [MaxLength(1000)]
    public string? Notes { get; set; }

    // Nawigacja
    public Animal? Animal { get; set; }
    public Address? Address { get; set; }
    
    // Właściwości obliczeniowe (nie są mapowane do bazy danych)
    public string? AnimalSpecies => Animal?.Species;
    public string? AnimalName => Animal?.Name;
    public string? AddressStreetAddress => Address?.StreetAddress;
    public string? AddressCity => Address?.City;
    public string? AddressPostalCode => Address?.PostalCode;
    public string? AddressCountry => Address?.Country;
}