using CadastroClienteEPedido.Models;
using CadastroClienteEPedido.ViewModel;

namespace CadastroClienteEPedido.IRepository;

public interface IClienteRepository
{
    List<Cliente> BuscarClientes();
    void CriarCliente(ClienteViewModel clienteModel);
    void AtualizarCliente(ClienteViewModel clienteModel, int id);
    void DeletarCliente(int id);
}