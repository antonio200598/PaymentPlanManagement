using PaymentPlanManagement_API.Domain.Entities;

namespace PaymentPlanManagement_API.Domain.Interfaces;

public interface IPaymentPlanRepository
{
    Task<PaymentPlan?> GetByIdAsync(long id);

    Task AddAsync(PaymentPlan p);

    Task<IEnumerable<PaymentPlan>> GetByClientAsync(long id);

    Task SaveChangesAsync();
}
