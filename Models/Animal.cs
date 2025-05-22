namespace AnimalShelter.Models;
using System.Collections.Generic;

public class Animal
{
    public int Id { get; set; }
    public string? Species { get; set; }
    public string? Breed { get; set; }
    public int? Age { get; set; }
    public string? Gender { get; set; }
    public string? Color { get; set; }
    public string? Size { get; set; }
    public string? Microchip { get; set; }
    public string? Location { get; set; }
    public bool? IsAdopted { get; set; }

    // Relacja: lista adopcji tego zwierzęcia
    public ICollection<Adoption>? Adoptions { get; set; }
}