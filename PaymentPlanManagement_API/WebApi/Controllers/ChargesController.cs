using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentPlanManagement_API.Domain.Interfaces;

namespace PaymentPlanManagement_API.WebApi.Controllers;

[ApiController]
[Route("api/cobrancas")]
public class ChargesController : ControllerBase
{
    private readonly IChargeRepository _repo;
  
    public ChargesController(IChargeRepository repo) => _repo = repo;

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id)
    {
        var charge = await _repo.GetByIdAsync(id);
        
        if (charge == null)
            return NotFound();
        
        return Ok(charge);
    }

    [HttpPost("{id}/pagamentos")]
    public async Task<IActionResult> Pagar(long id, decimal paymentValue, DateTime paymentDate)
    {
        var charge = await _repo.GetByIdAsync(id);
        
        if (charge == null)
            return NotFound();
        
        charge.RegisterPayment(paymentValue, paymentDate);
        
        await _repo.SaveChangesAsync();
        
        return Ok(charge);
    }
}
