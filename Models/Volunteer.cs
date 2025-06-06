namespace AnimalShelter.Models;
using System.ComponentModel.DataAnnotations;

public class Volunteer
{
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string FullName { get; set; } = null!;
    
    [MaxLength(150)]
    public string Email { get; set; } = null!;
    
    [MaxLength(20)]
    public string PhoneNumber { get; set; } = null!;
    
    [MaxLength(500)]
    public string? AdditionalNotes { get; set; }
    
    public int AddressId { get; set; }
    
    public Address? Address { get; set; }
    
    
    public string? AddressStreetAddress => Address?.StreetAddress;
    public string? AddressCity => Address?.City;
    public string? AddressPostalCode => Address?.PostalCode;
    public string? AddressCountry => Address?.Country;
}