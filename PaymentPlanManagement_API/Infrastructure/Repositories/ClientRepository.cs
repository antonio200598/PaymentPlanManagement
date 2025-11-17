using Microsoft.EntityFrameworkCore;
using PaymentPlanManagement_API.Domain.Entities;
using PaymentPlanManagement_API.Domain.Interfaces;
using PaymentPlanManagement_API.Infrastructure.Persistence;

namespace PaymentPlanManagement_API.Infrastructure.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context) => _context = context;

    public async Task AddAsync(Client r) => await _context.Client.AddAsync(r);

    public async Task<Client?> GetByIdAsync(long id)
    {
        try
        {
          return await _context.Client
              .FirstOrDefaultAsync(c => c.Id == id);
        }
        catch (Exception ex) 
        { 
            throw ex;
        }
    }

    public async Task<IEnumerable<Client>> ListAsync() =>  await _context.Client.ToListAsync();

    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
