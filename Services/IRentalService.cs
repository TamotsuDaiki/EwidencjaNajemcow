using EwidencjaNajemcow.Models;

namespace EwidencjaNajemcow.Services
{
    public interface IRentalService
    {
        Task<List<Rental>> GetAllAsync();
        Task<Rental?> GetByIdAsync(int id);
        Task AddAsync(Rental rental);
        Task UpdateAsync(Rental rental);
        Task DeleteAsync(int id);
    }
}
