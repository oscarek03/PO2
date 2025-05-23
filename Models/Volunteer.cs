namespace AnimalShelter.Models;

public class Volunteer
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }

    public int AddressId { get; set; }
    public string? AdditionalNotes { get; set; }
    
    public Address? Address { get; set; }
}