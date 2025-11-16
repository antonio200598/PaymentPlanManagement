using PaymentPlanManagement_API.Domain.Entities;

namespace PaymentPlanManagement_API.Domain.Interfaces;

public interface IClientRepository
{
    Task<Client?> GetByIdAsync(long id);

    Task<IEnumerable<Client>> ListAsync();

    Task AddAsync(Client r);

    Task SaveChangesAsync();
}
