namespace PaymentPlanManagement_API.Domain.Entities;

public class CostCenter
{
    public int Id { get; private set; }

    public string Name { get; private set; } = null!;

    public string? Code { get; private set; }

    protected CostCenter() { }

    public CostCenter(string name, string? code)
    {
        Name = name;
        Code = code;
    }
}
