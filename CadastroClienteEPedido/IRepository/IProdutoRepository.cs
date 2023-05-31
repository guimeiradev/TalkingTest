using CadastroClienteEPedido.Models;
using CadastroClienteEPedido.ViewModel;

namespace CadastroClienteEPedido.IRepository;

public interface IProdutoRepository
{
    List<Produto> BuscarProdutos();
    void CriarProduto(ProdutoViewModel produtoViewModel);
    void AtualizarProduto(ProdutoViewModel produtoViewModel, int id);
    void DeletarProduto(int id);
}