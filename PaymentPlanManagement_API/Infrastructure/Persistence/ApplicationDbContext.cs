using Microsoft.EntityFrameworkCore;
using PaymentPlanManagement_API.Domain.Entities;
using PaymentPlanManagement_API.Infrastructure.Persistence.Configurations;

namespace PaymentPlanManagement_API.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options){}

    public DbSet<Client> Client => Set<Client>();

    public DbSet<PaymentPlan> PaymentPlans => Set<PaymentPlan>();

    public DbSet<Charge> Charge => Set<Charge>();

    public DbSet<CostsCentral> CostsCenter => Set<CostsCentral>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Charge>()
        .Property(c => c.Value)
        .HasColumnType("decimal(18,2)");

        b.Entity<Charge>()
        .HasIndex(c => c.PaymentCode)
        .IsUnique();

        b.ApplyConfiguration(new PaymentPlanConfiguration());
        b.ApplyConfiguration(new ChargeConfiguration());
        b.ApplyConfiguration(new ClientConfiguration());

        base.OnModelCreating(b);
    }
}
