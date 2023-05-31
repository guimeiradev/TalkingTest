using CadastroClienteEPedido.Data;
using CadastroClienteEPedido.IRepository;
using CadastroClienteEPedido.Models;
using CadastroClienteEPedido.ViewModel;

namespace CadastroClienteEPedido.Repository;

public class PedidoRepository : IPedidoRepository
{
    private readonly CadastroClienteEPedidoDataContext _context;

    public PedidoRepository(CadastroClienteEPedidoDataContext context)
    {
        _context = context;
    }

    
    public List<Pedido> BuscarPedidos()
    {
        var pedidos = _context.Pedidos.ToList();

        return pedidos;
    }
    public void CriarPedido(PedidoViewModel pedidoViewModel)
    {
        var pedido = new Pedido()
        {
            Cliente = pedidoViewModel.Cliente,
            Produto = pedidoViewModel.Produto,
            ValorTotal = pedidoViewModel.ValorTotal,
            Status = pedidoViewModel.Status
        };
        
        _context.Pedidos.Add(pedido);
        _context.SaveChanges();
    }
    
    public void AtualizarPedido(PedidoViewModel pedidoViewModel, int id)
    {
        var pedido = _context
            .Pedidos
            .FirstOrDefault(x => x.Id == id);

        pedido.Cliente = pedidoViewModel.Cliente;
        pedido.Produto = pedidoViewModel.Produto;
        pedido.ValorTotal = pedidoViewModel.ValorTotal;
        pedido.Status = pedidoViewModel.Status;
        
        _context.Pedidos.Update(pedido);
        _context.SaveChanges();
    }
    
    public void DeletarPedido(int id)
    {
        var pedido = _context
            .Pedidos
            .FirstOrDefault(x => x.Id == id);

        _context.Pedidos.Remove(pedido);
        _context.SaveChanges();
        
    }
}