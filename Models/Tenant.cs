using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Tenant
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Imię")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Nazwisko")]
    public string LastName { get; set; } = string.Empty;

    [Display(Name = "PESEL")]
    public string? PESEL { get; set; }

    [Display(Name = "E-mail")]
    public string? Email { get; set; }

    [Display(Name = "Telefon")]
    public string? Phone { get; set; }

    // Nawigacja
    public ICollection<Rental> Rentals { get; set; } = new List<Rental>();

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
}
