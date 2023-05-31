using CadastroClienteEPedido.Models;
using CadastroClienteEPedido.Repository;
using CadastroClienteEPedido.ViewModel;

namespace CadastroClienteEPedido.Service;

public class ProdutoService 
{
    private readonly ProdutoRepository _repository;

    public ProdutoService(ProdutoRepository repository)
    {
        _repository = repository;
    }

    public List<Produto> BuscarProdutos()
    {
        return _repository.BuscarProdutos();
    }

    public void CriarProduto(ProdutoViewModel produtoViewModel)
    {
        _repository.CriarProduto(produtoViewModel);
    }
    
    public void AtualizarProduto(ProdutoViewModel produtoViewModel, int id)
    {
        _repository.AtualizarProduto(produtoViewModel, id);
    }
    
    public void DeletarProduto(int id)
    {
        _repository.DeletarProduto(id);
    }
}