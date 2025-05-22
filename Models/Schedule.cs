namespace AnimalShelter.Models;
using System;

public class Schedule
{
    public int Id { get; set; }
    public DateTime? EventDate { get; set; }
    public string? Title { get; set; }
    public string? Note { get; set; }
    public string? EventType { get; set; }
}