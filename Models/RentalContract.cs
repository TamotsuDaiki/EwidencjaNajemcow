using System.ComponentModel.DataAnnotations;

namespace EwidencjaNajemcow.Models
{
    public class RentalContract
    {
        public int Id { get; set; }

        [Required]
        public string ContractNumber { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int TenantId { get; set; }
        public Tenant Tenant { get; set; } = new();

        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; } = new();
    }
}
