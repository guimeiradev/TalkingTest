using CadastroClienteEPedido.Models;
using CadastroClienteEPedido.Repository;
using CadastroClienteEPedido.ViewModel;

namespace CadastroClienteEPedido.Service;

public class PedidoService
{
    private readonly PedidoRepository _repository;

    public PedidoService(PedidoRepository repository)
    {
        _repository = repository;
    }

    public List<Pedido> BuscarPedidos()
    {
        return _repository.BuscarPedidos();
    }

    public void CriarPedido(PedidoViewModel pedidoViewModel)
    {
        _repository.CriarPedido(pedidoViewModel);
    }
    
    public void AtualizarPedido(PedidoViewModel pedidoViewModel, int id)
    {
        _repository.AtualizarPedido(pedidoViewModel, id);
    }
    
    public void DeletarPedido(int id)
    {
        _repository.DeletarPedido(id);
    }
}