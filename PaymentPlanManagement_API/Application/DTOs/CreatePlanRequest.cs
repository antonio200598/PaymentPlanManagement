using PaymentPlanManagement_API.Domain.Enums;

namespace PaymentPlanManagement_API.Application.DTOs;

public record ChargeInput(
    decimal Value,
    DateTime DueDate,
    PaymentMethod PaymentMethod);

public record CreatePlanRequest(
    long Client_Id,
    long? CostsCentral_Id,
    string? CostsCentral_enum,
    List<ChargeInput> Charges);
