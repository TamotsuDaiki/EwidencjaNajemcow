

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

using System.ComponentModel.DataAnnotations;

public class Rental
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Numer umowy")]
    public string ContractNumber { get; set; } = string.Empty;

    [Display(Name = "Data rozpocz�cia")]
    public DateTime StartDate { get; set; }

    [Display(Name = "Data zako�czenia")]
    public DateTime EndDate { get; set; }

    [Display(Name = "Czynsz miesi�czny")]
    public decimal MonthlyRent { get; set; }

    [Display(Name = "Aktywna?")]
    public bool IsActive { get; set; }

    [Required]
    
    public int TenantId { get; set; }

    [ValidateNever]
    [Display(Name = "Najemca")]
    public Tenant? Tenant { get; set; }

    [Required]
    
    public int ApartmentId { get; set; }

    [ValidateNever]
    [Display(Name = "Mieszkanie")]
    public Apartment? Apartment { get; set; }
}
