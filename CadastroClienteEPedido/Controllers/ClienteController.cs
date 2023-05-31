using CadastroClienteEPedido.Models;
using CadastroClienteEPedido.Service;
using CadastroClienteEPedido.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClienteEPedido.Controllers;
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly ClienteService _service;
    public ClienteController(ClienteService service)
    {
        _service = service; 
    }

    [HttpGet("v1/clientes")]
    public IActionResult BuscarClientes()
    {
        try
        {
            var clientes = _service.BuscarClientes();

            return Ok(new ResultViewModel<List<Cliente>>(clientes));
        }
        catch
        {
            return Ok(new ResultViewModel<List<Cliente>>("Falha interna no servidor."));
        }
    }
    
    [HttpPost("v1/clientes")]
    public IActionResult CriarCliente([FromBody] ClienteViewModel model)
    {
        
        try
        {
            _service.CriarCliente(model);
            return Created($"v1/clientes/{model.Id}", model);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResultViewModel<Cliente>("05EXE9 - Falha interna no servidor."));
        }
    }
    
    [HttpPut("v1/clientes/{id}")]
    public async Task<IActionResult> AtualizarCliente([FromRoute] int id,[FromBody]ClienteViewModel model)
    {
        try
        {
           _service.AtualizarCliente(model,id);

            return Ok(model);
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Cliente>("05EXE9 - Falha interna no servidor."));
        }
    }
    
    [HttpDelete("v1/clientes/{id}")]
    public async Task<IActionResult> DeleteAsync(
        [FromRoute] int id)
    {
        try
        {

            return Ok(_service.DeletarCliente);
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Cliente>("05EXE9 - Falha interna no servidor."));
        }
    }

    
}