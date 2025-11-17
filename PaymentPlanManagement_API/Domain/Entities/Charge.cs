using PaymentPlanManagement_API.Domain.Enums;
using System.Drawing;

namespace PaymentPlanManagement_API.Domain.Entities;

public class Charge
{
    public long Id { get; private set; }

    public long PaymentPlans_Id { get; private set; }

    public PaymentPlan PaymentPlan { get; private set; } = null!;

    public decimal Value { get; private set; }

    public DateTime DueDate { get; private set; }

    public PaymentMethod PaymentMethod { get; private set; }

    public ChargeStatus Status { get; private set; }

    public string PaymentCode { get; private set; } = null!;

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    protected Charge() { }

    public Charge(decimal value, DateTime due, PaymentMethod paymentMethod)
    {
        Value = value;
        DueDate = due;
        PaymentMethod = paymentMethod;
        PaymentCode  = GenerateCode(paymentMethod);
    }

    private static string GenerateCode(PaymentMethod paymentMethod)
    {
        try
        {
            return paymentMethod == PaymentMethod.Boleto
                ? $"836{Guid.NewGuid():N}".PadRight(47, '0').Substring(0, 47)
                : $"PIX-{Guid.NewGuid():N}";
        }
        catch
        {
            throw;
        }
    }

    public bool IsDue()
    {
        return Status == ChargeStatus.Created && DateTime.UtcNow.Date > DueDate.Date;
    }

    public void RegisterPayment(decimal value, DateTime date)
    {
        if(Value < value)
          throw new Exception("Pagamento parcial não permitido.");

        Status = ChargeStatus.Paid;
    }

    public void CancelPayment()
    {
        if(Status == ChargeStatus.Paid)
          throw new Exception("Não é possível cancelar uma cobrança paga.");

        Status = ChargeStatus.Canceled;
    }
}
