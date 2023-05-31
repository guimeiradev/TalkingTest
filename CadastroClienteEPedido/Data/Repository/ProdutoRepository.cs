using CadastroClienteEPedido.Data;
using CadastroClienteEPedido.IRepository;
using CadastroClienteEPedido.Models;
using CadastroClienteEPedido.ViewModel;

namespace CadastroClienteEPedido.Repository;

public class ProdutoRepository : IProdutoRepository
{
    private readonly CadastroClienteEPedidoDataContext _context;

    public ProdutoRepository(CadastroClienteEPedidoDataContext context)
    {
        _context = context;
    }

    public List<Produto> BuscarProdutos()
    {
        var produtos = _context.Produtos
            .Where(x => x.Ativo == true).ToList();

        return produtos;
    }

    public void CriarProduto(ProdutoViewModel produtoViewModel)
    {
        var produto = new Produto()
        {
            Nome = produtoViewModel.Nome,
            Ativo = produtoViewModel.Ativo
        };

        _context.Produtos.Add(produto);
        _context.SaveChanges();
    }

    public void AtualizarProduto(ProdutoViewModel produtoViewModel, int id)
    {
        var produto = _context
            .Produtos
            .FirstOrDefault(x => x.Id == id);

        produto.Nome = produtoViewModel.Nome;
        produto.Ativo = produtoViewModel.Ativo;
        
        _context.Produtos.Update(produto);
        _context.SaveChanges();
    }

    public void DeletarProduto(int id)
    {
        var produto = _context
            .Produtos
            .FirstOrDefault(x => x.Id == id);

        _context.Produtos.Remove(produto);
        _context.SaveChanges();
        
    }
}