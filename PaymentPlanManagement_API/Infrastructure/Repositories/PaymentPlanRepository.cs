using Microsoft.EntityFrameworkCore;
using PaymentPlanManagement_API.Domain.Entities;
using PaymentPlanManagement_API.Domain.Interfaces;
using PaymentPlanManagement_API.Infrastructure.Persistence;

namespace PaymentPlanManagement_API.Infrastructure.Repositories;

public class PaymentPlanRepository : IPaymentPlanRepository
{
    private readonly ApplicationDbContext _context;

    public PaymentPlanRepository(ApplicationDbContext context) => _context = context;

    public async Task AddAsync(PaymentPlan p) => await _context.PaymentPlans.AddAsync(p);

    public async Task<PaymentPlan?> GetByIdAsync(long id)
    {
        return await _context.PaymentPlans.Include( p => p.Charges).FirstOrDefaultAsync( p => p.Id == id);
    }

    public async Task<IEnumerable<PaymentPlan>> GetByClientAsync(long id)
    {
        return await _context.PaymentPlans.Where(p => p.Client_Id == id).Include(p => p.Charges).ToListAsync();
    }

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
