
using EwidencjaNajemcow.Models;
using Microsoft.EntityFrameworkCore;

namespace EwidencjaNajemcow.Services
{
    public class RentalService : IRentalService
    {
        private readonly AppDbContext _context;

        public RentalService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rental>> GetAllAsync()
        {
            return await _context.Rentals.ToListAsync();
        }

        public async Task<Rental?> GetByIdAsync(int id)
        {
            return await _context.Rentals.FindAsync(id);
        }

        public async Task AddAsync(Rental rental)
        {
            var tenant = await _context.Tenants.FindAsync(rental.TenantId);
            var apartment = await _context.Apartments.FindAsync(rental.ApartmentId);

            if (apartment != null && tenant != null)
            {
                apartment.IsRented = true;
                apartment.RentedBy = $"{tenant.FirstName} {tenant.LastName}";
            }

            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rental rental)
        {
            var tenant = await _context.Tenants.FindAsync(rental.TenantId);
            var apartment = await _context.Apartments.FindAsync(rental.ApartmentId);

            if (apartment != null && tenant != null)
            {
                apartment.IsRented = rental.IsActive;
                apartment.RentedBy = rental.IsActive
                    ? $"{tenant.FirstName} {tenant.LastName}"
                    : null;
            }

            _context.Rentals.Update(rental);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental != null)
            {
                _context.Rentals.Remove(rental);
                await _context.SaveChangesAsync();
            }
        }
    }
}
