using Microsoft.EntityFrameworkCore;
using PaymentPlanManagement_API.Domain.Entities;
using PaymentPlanManagement_API.Domain.Interfaces;
using PaymentPlanManagement_API.Infrastructure.Persistence;

namespace PaymentPlanManagement_API.Infrastructure.Repositories;

public class CostsCentralRepository : ICostsCentralRepository
{
    private readonly ApplicationDbContext _context;

    public CostsCentralRepository(ApplicationDbContext context) => _context = context;

    public async Task AddAsync(CostsCentral c) => await _context.CostsCentral.AddAsync(c);

    public async Task<CostsCentral?> GetByIdAsync(long id)
    {
        return await _context.CostsCentral.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<CostsCentral>> ListAsync() => await _context.CostsCentral.ToListAsync();

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
