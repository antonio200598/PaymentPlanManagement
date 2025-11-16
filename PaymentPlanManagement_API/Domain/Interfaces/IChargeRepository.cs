using PaymentPlanManagement_API.Domain.Entities;

namespace PaymentPlanManagement_API.Domain.Interfaces;

public interface IChargeRepository
{
    Task<Charge?> GetByIdAsync(long id);

    Task AddAsync(Charge c);

    Task<IEnumerable<Charge>> GetByClientAsync(long id);

    Task<int> CountByClientAsync(long clientId);

    Task SaveChangesAsync();
}
