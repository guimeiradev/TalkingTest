using CadastroClienteEPedido.Models;
using CadastroClienteEPedido.ViewModel;

namespace CadastroClienteEPedido.IRepository;

public interface IPedidoRepository
{
    List<Pedido> BuscarPedidos();
    void CriarPedido(PedidoViewModel pedidoViewModel);
    void AtualizarPedido(PedidoViewModel pedidoViewModel, int id);
    void DeletarPedido(int id);
}