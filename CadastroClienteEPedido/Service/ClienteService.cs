using CadastroClienteEPedido.Models;
using CadastroClienteEPedido.Repository;
using CadastroClienteEPedido.ViewModel;

namespace CadastroClienteEPedido.Service;

public class ClienteService 
{
    private readonly ClienteRepository _repository;

    public ClienteService(ClienteRepository repository)
    {
        _repository = repository;
    }

    public List<Cliente> BuscarClientes()
    {
        return _repository.BuscarClientes();
    }

    public void CriarCliente(ClienteViewModel clienteViewModel)
    {
         _repository.CriarCliente(clienteViewModel);
    }
    
    public void AtualizarCliente(ClienteViewModel clienteViewModel, int id)
    {
        _repository.AtualizarCliente(clienteViewModel, id);
    }
    
    public void DeletarCliente(int id)
    {
        _repository.DeletarCliente(id);
    }
}