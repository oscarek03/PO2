namespace AnimalShelter.Models;

public class Volunteer
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? StreetAddress { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public int? Roles { get; set; }
    public int? Availability { get; set; }
    public string? AdditionalNotes { get; set; }
}