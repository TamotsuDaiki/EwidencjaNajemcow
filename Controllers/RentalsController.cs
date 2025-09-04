using EwidencjaNajemcow.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

[Authorize]
public class RentalsController : Controller
{
    private readonly IRentalService _rentalService;
    private readonly AppDbContext _context;

    public RentalsController(IRentalService rentalService, AppDbContext context)
    {
        _rentalService = rentalService;
        _context = context;
    }

    // GET: Rentals
    public async Task<IActionResult> Index()
    {
        var rentals = await _rentalService.GetAllAsync();
        return View(rentals);
    }

    // GET: Rentals/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var rental = await _rentalService.GetByIdAsync(id.Value);
        if (rental == null) return NotFound();

        return View(rental);
    }

    // GET: Rentals/Create
    public IActionResult Create()
    {
        ViewBag.Tenants = new SelectList(_context.Tenants, "Id", "FullName");
        ViewBag.Apartments = new SelectList(_context.Apartments, "Id", "AddressSummary");
        return View();
    }

    // POST: Rentals/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("ContractNumber,StartDate,EndDate,MonthlyRent,IsActive,TenantId,ApartmentId")]
        Rental rental)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Tenants = new SelectList(_context.Tenants, "Id", "FullName", rental.TenantId);
            ViewBag.Apartments = new SelectList(_context.Apartments, "Id", "AddressSummary", rental.ApartmentId);
            return View(rental);
        }

        await _rentalService.AddAsync(rental);
        await _rentalService.UpdateAsync(rental);

        return RedirectToAction(nameof(Index));
    }

    // GET: Rentals/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var rental = await _rentalService.GetByIdAsync(id.Value);
        if (rental == null) return NotFound();

        ViewBag.Tenants = new SelectList(_context.Tenants, "Id", "FullName", rental.TenantId);
        ViewBag.Apartments = new SelectList(_context.Apartments, "Id", "AddressSummary", rental.ApartmentId);
        return View(rental);
    }

    // POST: Rentals/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(
        int id,
        [Bind("Id,ContractNumber,StartDate,EndDate,MonthlyRent,IsActive,TenantId,ApartmentId")]
        Rental rental)
    {
        if (id != rental.Id) return NotFound();

        if (!ModelState.IsValid)
        {
            ViewBag.Tenants = new SelectList(_context.Tenants, "Id", "FullName", rental.TenantId);
            ViewBag.Apartments = new SelectList(_context.Apartments, "Id", "AddressSummary", rental.ApartmentId);
            return View(rental);
        }

        await _rentalService.UpdateAsync(rental);
        return RedirectToAction(nameof(Index));
    }

    // GET: Rentals/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var rental = await _rentalService.GetByIdAsync(id.Value);
        if (rental == null) return NotFound();

        return View(rental);
    }

    // POST: Rentals/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _rentalService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
