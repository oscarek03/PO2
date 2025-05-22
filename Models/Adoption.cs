namespace AnimalShelter.Models;
using System;

public class Adoption
{
    public int Id { get; set; }
    public int AnimalId { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? AdoptionDate { get; set; }
    public int IdAddress { get; set; }
    public string? Notes { get; set; }

    // Nawigacja
    public Animal? Animal { get; set; }
    public Address? Address { get; set; }
}