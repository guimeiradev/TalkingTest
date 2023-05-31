using CadastroClienteEPedido.Data.Map;
using CadastroClienteEPedido.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClienteEPedido.Data;

public class CadastroClienteEPedidoDataContext : DbContext
{
    public CadastroClienteEPedidoDataContext(DbContextOptions<CadastroClienteEPedidoDataContext> options)
        : base(options)
    {
    }
    
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClienteMap());
        modelBuilder.ApplyConfiguration(new ProdutoMap());
        modelBuilder.ApplyConfiguration(new PedidoMap());
    }
}