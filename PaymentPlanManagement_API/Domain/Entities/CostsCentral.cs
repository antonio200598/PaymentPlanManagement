namespace PaymentPlanManagement_API.Domain.Entities;

public class CostsCentral
{
    public int Id { get; private set; }

    public string Name { get; private set; } = null!;

    public string? Code { get; private set; }

    protected CostsCentral() { }

    public CostsCentral(string name, string? code)
    {
        Name = name;
        Code = code;
    }
}
