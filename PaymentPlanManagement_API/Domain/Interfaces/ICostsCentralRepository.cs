using PaymentPlanManagement_API.Domain.Entities;

namespace PaymentPlanManagement_API.Domain.Interfaces;

public interface ICostsCentralRepository
{
    Task<IEnumerable<CostsCentral>> ListAsync();
    
    Task<CostsCentral?> GetByIdAsync(long id);
    
    Task AddAsync(CostsCentral c);
    
    Task SaveChangesAsync();
}
