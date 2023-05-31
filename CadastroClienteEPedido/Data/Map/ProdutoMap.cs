using CadastroClienteEPedido.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroClienteEPedido.Data.Map;

public class ProdutoMap : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produto");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id) 
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();
        builder.Property(x => x.Nome)
            .HasColumnType("VARCHAR")
            .HasMaxLength(50);
        builder.Property(x => x.Ativo)
            .HasColumnType("BIT");
    }
}