namespace AnimalShelter.Models;
using System;

public class Donation
{
    public int Id { get; set; }
    public string? DonorName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public decimal? Amount { get; set; }
    public string? DonationType { get; set; }
    public string? PaymentMethod { get; set; }
    public DateTime? DonationDate { get; set; }
    public string? NotesOrDedication { get; set; }
}