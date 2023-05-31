using CadastroClienteEPedido.Models;
using CadastroClienteEPedido.Service;
using CadastroClienteEPedido.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClienteEPedido.Controllers;
[ApiController]
public class PedidoController : ControllerBase
{
    public PedidoController(PedidoService service)
    {
        _service = service;
    }

    private readonly PedidoService _service;
    
    

    [HttpGet("v1/pedidos")]
    public IActionResult BuscarPedidos()
    {
        try
        {
            var pedidos = _service.BuscarPedidos();

            return Ok(new ResultViewModel<List<Pedido>>(pedidos));
        }
        catch
        {
            return Ok(new ResultViewModel<List<Pedido>>("Falha interna no servidor."));
        }
    }
    
    [HttpPost("v1/pedidos")]
    public IActionResult CriarPedido([FromBody] PedidoViewModel model)
    {
        
        try
        {
            _service.CriarPedido(model);
            return Created($"v1/pedidos/{model.Id}", model);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResultViewModel<Pedido>("05EXE9 - Falha interna no servidor."));
        }
    }
    
    [HttpPut("v1/pedidos/{id}")]
    public async Task<IActionResult> AtualizarPedido([FromRoute] int id,[FromBody]PedidoViewModel model)
    {
        try
        {
            _service.AtualizarPedido(model,id);

            return Ok(model);
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Pedido>("05EXE9 - Falha interna no servidor."));
        }
    }
    
    [HttpDelete("v1/pedidos/{id}")]
    public async Task<IActionResult> DeletarPedido(
        [FromRoute] int id)
    {
        try
        {

            return Ok(_service.DeletarPedido);
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Pedido>("05EXE9 - Falha interna no servidor."));
        }
    }
}