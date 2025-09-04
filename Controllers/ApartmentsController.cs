
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace EwidencjaNajemcow.Controllers
{
    
    public class ApartmentsController : Controller
    {
        private readonly AppDbContext _context;

        public ApartmentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Apartments
        public async Task<IActionResult> Index()
        {
            return View(await _context.Apartments.ToListAsync());
        }

        // GET: Apartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var apartment = await _context.Apartments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartment == null) return NotFound();

            return View(apartment);
        }

        // GET: Apartments/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Apartments/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(
            "Street,BuildingNumber,ApartmentNumber,City,PostalCode,NumberOfRooms,Area")]
            Apartment apartment)
        {
            if (ModelState.IsValid)
            {
                apartment.IsRented = false;
                apartment.RentedBy = null;

                _context.Add(apartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(apartment);
        }

        // GET: Apartments/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment == null) return NotFound();

            return View(apartment);
        }

        // POST: Apartments/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(
            "Id,Street,BuildingNumber,ApartmentNumber,City,PostalCode,IsRented,NumberOfRooms,Area,RentedBy")]
            Apartment apartment)
        {
            if (id != apartment.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(apartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Apartments.Any(e => e.Id == apartment.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(apartment);
        }

        // GET: Apartments/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var apartment = await _context.Apartments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (apartment == null) return NotFound();

            return View(apartment);
        }

        // POST: Apartments/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apartment = await _context.Apartments.FindAsync(id);
            if (apartment != null)
            {
                _context.Apartments.Remove(apartment);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
