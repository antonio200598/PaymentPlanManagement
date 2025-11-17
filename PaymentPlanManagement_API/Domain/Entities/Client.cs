namespace PaymentPlanManagement_API.Domain.Entities;

public class Client
{
    public long Id { get; private set; }

    public string Name { get; private set; } = null!;

    public ICollection<PaymentPlan> PaymentPlans { get; private set; } = new List<PaymentPlan>();

    protected Client() { }

    public Client(string name)
    {
        Name = name;
    }
}
