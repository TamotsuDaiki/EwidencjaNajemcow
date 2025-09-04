namespace EwidencjaNajemcow.ViewModels
{
    public class RentalViewModel
    {
        public int Id { get; set; }
        public string TenantName { get; set; } = string.Empty;
        public string ApartmentAddress { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal MonthlyRent { get; set; }
        public bool IsActive { get; set; }
    }
}
