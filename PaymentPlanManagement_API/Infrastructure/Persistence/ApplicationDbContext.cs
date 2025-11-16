using Microsoft.EntityFrameworkCore;
using PaymentPlanManagement_API.Domain.Entities;

namespace PaymentPlanManagement_API.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options){}

    public DbSet<Client> Clients => Set<Client>();

    public DbSet<PaymentPlan> PaymentPlans => Set<PaymentPlan>();

    public DbSet<Charge> Charges => Set<Charge>();

    public DbSet<CostCenter> CostCenters => Set<CostCenter>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Charge>()
        .Property(c => c.Value)
        .HasColumnType("decimal(18,2)");

        b.Entity<Charge>()
        .HasIndex(c => c.PaymentCode)
        .IsUnique();
    }
}
