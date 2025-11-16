using PaymentPlanManagement_API.Domain.Enums;

namespace PaymentPlanManagement_API.Application.DTOs;

public record ChargeInput(
    decimal Value,
    DateTime DueDate,
    PaymentMethod PaymentMethod);

public record CreatePlanRequest(
    long ClientId,
    long? CostCenterId,
    string? CostCenterEnum,
    List<ChargeInput> Charges);
