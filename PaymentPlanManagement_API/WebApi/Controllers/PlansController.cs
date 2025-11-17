using Microsoft.AspNetCore.Mvc;
using PaymentPlanManagement_API.Application.DTOs;
using PaymentPlanManagement_API.Domain.Entities;
using PaymentPlanManagement_API.Domain.Interfaces;

namespace PaymentPlanManagement_API.WebApi.Controllers;

[ApiController]
[Route("api/planos-de-pagamento")]
public class PlansController : ControllerBase
{
    private readonly IPaymentPlanRepository _paymentPlanRepo;
    private readonly IClientRepository _clientRepo;
    private readonly IChargeRepository _chargeRepo;

    public PlansController(
        IPaymentPlanRepository paymentPlanRepo,
        IClientRepository clientRepo,
        IChargeRepository chargeRepo)
    {
        _paymentPlanRepo = paymentPlanRepo;
        _clientRepo = clientRepo;
        _chargeRepo = chargeRepo;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePlanRequest request)
    {
        var client = await _clientRepo.GetByIdAsync(request.Client_Id);

        if (client == null)
            return BadRequest("Responsável não encontrado");
        
        var plan = new PaymentPlan(request.Client_Id, request.CostsCentral_Id, request.CostsCentral_enum);
        
        foreach (var chargeDto in request.Charges)
        {
            var charge = new Charge(
               chargeDto.Value, 
               chargeDto.DueDate, 
               chargeDto.PaymentMethod);
            
            plan.Charges.Add(charge);

            await _chargeRepo.AddAsync(charge);
        }

        await _paymentPlanRepo.AddAsync(plan);
        
        await _paymentPlanRepo.SaveChangesAsync();
        
        return Created($"/api/planos-de-pagamento/{plan.Id}", plan);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Consultar(long id)
    {
        var plan = await _paymentPlanRepo.GetByIdAsync(id);
        
        if (plan == null)
            return NotFound();
        
        return Ok(plan);
    }

    [HttpGet("{id}/total")]
    public async Task<IActionResult> Total(long id)
    {
        var plan = await _paymentPlanRepo.GetByIdAsync(id);
        
        if (plan == null)
            return NotFound();
        
        return Ok(new { TotalValue = plan.TotalValue });
    }
}
