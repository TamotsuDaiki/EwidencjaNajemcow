using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Apartment
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Ulica")]
    public string Street { get; set; } = string.Empty;

    [Display(Name = "Numer bloku")]
    public string? BuildingNumber { get; set; }

    [Display(Name = "Numer mieszkania")]
    public string? ApartmentNumber { get; set; }

    [Required]
    [Display(Name = "Miasto")]
    public string City { get; set; } = string.Empty;

    [Display(Name = "Kod pocztowy")]
    public string? PostalCode { get; set; }

    [Display(Name = "Czy wynajęte?")]
    public bool IsRented { get; set; }

    [Display(Name = "Liczba pokoi")]
    public int NumberOfRooms { get; set; }

    [Display(Name = "Metraż (m²)")]
    public double Area { get; set; }

    [Display(Name = "Wynajmujący")]
    public string? RentedBy { get; set; }

    // Nawigacja
    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    [NotMapped]
    [Display(Name = "Adres")]
    public string AddressSummary =>
        string.IsNullOrEmpty(ApartmentNumber)
            ? $"{City}, {Street} {BuildingNumber}"
            : $"{City}, {Street} {BuildingNumber}/{ApartmentNumber}";
}
