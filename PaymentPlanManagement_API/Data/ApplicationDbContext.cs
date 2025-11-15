using Microsoft.EntityFrameworkCore;

namespace PaymentPlanManagement_API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<PaymentPlan> PaymentPlans { get; set; }
}
