namespace AnimalShelter.Models;
using System.Collections.Generic;

public class Address
{
    public int Id { get; set; }
    public string StreetAddress { get; set; } = null!;
    public string City { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string Country { get; set; } = null!;

    // Relacja: lista adopcji pod tym adresem
    public ICollection<Adoption>? Adoptions { get; set; }
}