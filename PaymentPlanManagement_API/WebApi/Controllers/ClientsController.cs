using Microsoft.AspNetCore.Mvc;
using PaymentPlanManagement_API.Application.DTOs;
using PaymentPlanManagement_API.Domain.Entities;
using PaymentPlanManagement_API.Domain.Interfaces;

namespace PaymentPlanManagement_API.WebApi.Controllers;

[ApiController]
[Route("api/responsaveis")]
public class ClientsController : ControllerBase
{
    private readonly IClientRepository _repo;
    public ClientsController(IClientRepository repo) => _repo = repo;

    [HttpPost]
    public async Task<IActionResult> CreateClient(CreateClientRequest client)
    {
        var clientEntity = new Client(client.Name);
        
        await _repo.AddAsync(clientEntity);

        await _repo.SaveChangesAsync();

        return Created($"/api/responsaveis/{clientEntity.Id}", clientEntity);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(long id) 
    { 
        var client = await _repo.GetByIdAsync(id);

        if (client == null) 
          return NotFound();

        return Ok(client);
    }

    [HttpGet]
    public async Task<IActionResult> Listar() 
    { 
        return Ok(await _repo.ListAsync());
    }
}
