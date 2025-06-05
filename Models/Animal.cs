namespace AnimalShelter.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Animal
{
    public int Id { get; set; }
    
    [MaxLength(50)]
    public string? Name { get; set; }
    
    [MaxLength(30)]
    public string? Species { get; set; }
    
    [MaxLength(50)]
    public string? Breed { get; set; }
    
    public int? Age { get; set; }
    
    [MaxLength(10)]
    public string? Gender { get; set; }
    
    [MaxLength(30)]
    public string? Color { get; set; }
    
    [MaxLength(20)]
    public string? Size { get; set; }
    
    [MaxLength(20)]
    public string? Microchip { get; set; }
    
    [MaxLength(100)]
    public string? Location { get; set; }
    
    public bool? IsAdopted { get; set; }

    // Relacja: lista adopcji tego zwierzęcia
    public ICollection<Adoption>? Adoptions { get; set; }
}