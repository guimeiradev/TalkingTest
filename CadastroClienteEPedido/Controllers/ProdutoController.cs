using CadastroClienteEPedido.Models;
using CadastroClienteEPedido.Service;
using CadastroClienteEPedido.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClienteEPedido.Controllers;
[ApiController]
public class ProdutoController : ControllerBase
{
    public ProdutoController(ProdutoService service)
    {
        _service = service;
    }

    private readonly ProdutoService _service;
    
    [HttpGet("v1/produtos")]
    public IActionResult BuscarProdutos()
    {
        try
        {
            var produtos = _service.BuscarProdutos();

            return Ok(new ResultViewModel<List<Produto>>(produtos));
        }
        catch
        {
            return Ok(new ResultViewModel<List<Pedido>>("Falha interna no servidor."));
        }
    }
    
    [HttpPost("v1/produtos")]
    public IActionResult CriarPedido([FromBody] ProdutoViewModel model)
    {
        
        try
        {
            _service.CriarProduto(model);
            return Created($"v1/produtos/{model.Id}", model);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResultViewModel<Pedido>("05EXE9 - Falha interna no servidor."));
        }
    }
    
    [HttpPut("v1/produtos/{id}")]
    public async Task<IActionResult> AtualizarPedido([FromRoute] int id,[FromBody]ProdutoViewModel model)
    {
        try
        {
            _service.AtualizarProduto(model,id);

            return Ok(model);
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Pedido>("05EXE9 - Falha interna no servidor."));
        }
    }
    
    [HttpDelete("v1/produtos/{id}")]
    public async Task<IActionResult> DeletarPedido(
        [FromRoute] int id)
    {
        try
        {

            return Ok(_service.DeletarProduto);
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<Pedido>("05EXE9 - Falha interna no servidor."));
        }
    }

}