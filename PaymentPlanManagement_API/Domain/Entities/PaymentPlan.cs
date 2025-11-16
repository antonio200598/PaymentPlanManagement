namespace PaymentPlanManagement_API.Domain.Entities;

public class PaymentPlan
{
    public long Id { get; private set; }

    public long ClientId { get; private set; }

    public Client Client { get; private set; } = null!;

    public long? CostCenterId { get; private set; }

    public CostCenter? CostCenter { get; private set; }

    public string? CostCenterEnum { get; private set; }

    public ICollection<Charge> Charges { get; private set; } = new List<Charge>();

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;


    public decimal TotalValue => Charges.Sum(c => c.Value);


    protected PaymentPlan() { }

    public PaymentPlan(long clientId, long? costCenterId, string? costCenterEnum)
    {
      ClientId = clientId;
      CostCenterId = costCenterId;
      CostCenterEnum = costCenterEnum;
    }
}
