using Microsoft.EntityFrameworkCore;
using PaymentPlanManagement_API.Domain.Entities;
using PaymentPlanManagement_API.Domain.Interfaces;
using PaymentPlanManagement_API.Infrastructure.Persistence;

namespace PaymentPlanManagement_API.Infrastructure.Repositories;

public class ChargeRepository : IChargeRepository
{
    private readonly ApplicationDbContext _context;

    public ChargeRepository(ApplicationDbContext context) => _context = context;

    public async Task AddAsync(Charge c) => await _context.Charges.AddAsync(c);

    public async Task<Charge?> GetByIdAsync(long id)
    {
        return await _context.Charges.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Charge>> GetByClientAsync(long id)
    {
        return await _context.Charges
            .Include(c => c.PaymentPlan)
            .Where(c => c.PaymentPlan.ClientId == id)
            .ToListAsync();
    }

    public async Task<int> CountByClientAsync(long clientId)
    {
        return await _context.Charges
            .CountAsync(c => c.PaymentPlan.ClientId == clientId);
    }

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
