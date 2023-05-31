using CadastroClienteEPedido.Data;
using CadastroClienteEPedido.IRepository;
using CadastroClienteEPedido.Models;
using CadastroClienteEPedido.ViewModel;

namespace CadastroClienteEPedido.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly CadastroClienteEPedidoDataContext _context;

    public ClienteRepository(CadastroClienteEPedidoDataContext context)
    {
        _context = context;
    }

    public List<Cliente> BuscarClientes()
    {
        var clientes = _context.Clientes
            .Where(x => x.Ativo == true).ToList();

        return clientes;
    }

    public void CriarCliente(ClienteViewModel clienteModel)
    {
        var cliente = new Cliente
        {
            Nome = clienteModel.Nome,
            Ativo = clienteModel.Ativo
        };

        _context.Clientes.Add(cliente);
        _context.SaveChanges();
    }

    public void AtualizarCliente(ClienteViewModel clienteModel, int id)
    {
        var cliente = _context
            .Clientes
            .FirstOrDefault(x => x.Id == id);

        cliente.Nome = clienteModel.Nome;
        cliente.Ativo = clienteModel.Ativo;
        
        _context.Clientes.Update(cliente);
        _context.SaveChanges();
    }

    public void DeletarCliente(int id)
    {
        var cliente = _context
            .Clientes
            .FirstOrDefault(x => x.Id == id);

        _context.Clientes.Remove(cliente);
        _context.SaveChanges();
        
    }
}