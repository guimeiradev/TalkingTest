using CadastroClienteEPedido.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroClienteEPedido.Data.Map;

public class PedidoMap : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedido");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id) 
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        builder.Property(x => x.Cliente)
            .HasColumnType("VARCHAR")
            .HasMaxLength(50);
        builder.Property(x => x.Produto)
            .HasColumnType("VARCHAR")
            .HasMaxLength(50);
        builder.Property(x => x.ValorTotal)
            .HasColumnType("DECIMAL");
        builder.Property(x => x.Status)
            .HasColumnType("INT");
    }
}