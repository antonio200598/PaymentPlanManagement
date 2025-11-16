using Microsoft.EntityFrameworkCore;
using PaymentPlanManagement_API.Domain.Entities;
using PaymentPlanManagement_API.Domain.Interfaces;
using PaymentPlanManagement_API.Infrastructure.Persistence;

namespace PaymentPlanManagement_API.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context) => _context = context;

    public async Task AddAsync(Client r) => await _context.Clients.AddAsync(r);

    public async Task<Client?> GetByIdAsync(long id)
    {
        return await _context.Clients
            .Include(c => c.Plans)
            .ThenInclude(p => p.Charges)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<Client>> ListAsync() =>  await _context.Clients.ToListAsync();

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
