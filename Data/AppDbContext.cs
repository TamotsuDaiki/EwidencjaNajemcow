using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<ApplicationUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Rental> Rentals { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<Apartment> Apartments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Rental>()
            .HasOne(r => r.Tenant)
            .WithMany(t => t.Rentals)
            .HasForeignKey(r => r.TenantId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Rental>()
            .HasOne(r => r.Apartment)
            .WithMany(a => a.Rentals)
            .HasForeignKey(r => r.ApartmentId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
