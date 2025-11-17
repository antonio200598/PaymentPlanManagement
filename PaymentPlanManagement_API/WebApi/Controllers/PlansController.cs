using Microsoft.AspNetCore.Mvc;
using PaymentPlanManagement_API.Application.DTOs;
using PaymentPlanManagement_API.Domain.Entities;
using PaymentPlanManagement_API.Domain.Interfaces;
using System;
using System.Runtime.InteropServices;

namespace PaymentPlanManagement_API.WebApi.Controllers;

[ApiController]
[Route("api/planos-de-pagamento")]
public class PlansController : ControllerBase
{
    private readonly IPaymentPlanRepository _paymentPlanRepo;
    private readonly IClientRepository _clientRepo;
    private readonly IChargeRepository _chargeRepo;
    private readonly ICostsCentralRepository _costsCentralRepo;

  public PlansController
  (
        IPaymentPlanRepository paymentPlanRepo,
        IClientRepository clientRepo,
        IChargeRepository chargeRepo,
        ICostsCentralRepository costsCentralRepo
  )
  {
        _paymentPlanRepo = paymentPlanRepo;
        _clientRepo = clientRepo;
        _chargeRepo = chargeRepo;
        _costsCentralRepo = costsCentralRepo;
  }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePlanRequest request)
    {
        var client = await _clientRepo.GetByIdAsync(request.Client_Id);

        if (client == null)
            return BadRequest("Responsável não encontrado");

        CostsCentral costsCentral = await _costsCentralRepo.GetByIdAsync(request.CostsCentral_Id.Value);
        
        if(costsCentral == null) 
        { 
            costsCentral = new CostsCentral(request.CostsCentral_enum, new Random().Next(99).ToString() );
        
            await _costsCentralRepo.AddAsync(costsCentral);

            await _costsCentralRepo.SaveChangesAsync();
        }

        var plan = new PaymentPlan(request.Client_Id, costsCentral.Id, costsCentral.Name);
        
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
        
        await _chargeRepo.SaveChangesAsync();
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
