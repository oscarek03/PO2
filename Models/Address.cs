namespace AnimalShelter.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Address
{
    public int Id { get; set; }
    
    [MaxLength(200)]
    public string StreetAddress { get; set; } = null!;
    
    [MaxLength(100)]
    public string City { get; set; } = null!;
    
    [MaxLength(20)]
    public string PostalCode { get; set; } = null!;
    
    [MaxLength(100)]
    public string Country { get; set; } = null!;

    // Relacja: lista adopcji pod tym adresem
    public ICollection<Adoption>? Adoptions { get; set; }
}