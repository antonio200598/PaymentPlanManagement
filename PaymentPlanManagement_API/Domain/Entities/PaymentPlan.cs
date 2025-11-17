using System.Text.Json.Serialization;

namespace PaymentPlanManagement_API.Domain.Entities;

public class PaymentPlan
{
    public long Id { get; private set; }

    public long Client_Id { get; private set; }

    [JsonIgnore]
    public Client Client { get; private set; } = null!;

    public long? CostsCentral_Id { get; private set; }

    [JsonIgnore]
    public CostsCentral? CostsCentral { get; private set; }

    public string? CostsCentral_enum { get; private set; }

    [JsonIgnore]
    public ICollection<Charge> Charges { get; private set; } = new List<Charge>();

    public DateTime created_at { get; private set; } = DateTime.UtcNow;


    public decimal TotalValue => Charges.Sum(c => c.Value);


    protected PaymentPlan() { }

    public PaymentPlan(long client_Id, long? costsCentral_Id, string? costsCentral_Enum)
    {
        Client_Id = client_Id;
        CostsCentral_Id = costsCentral_Id;
        CostsCentral_enum = costsCentral_Enum;
    }
}
