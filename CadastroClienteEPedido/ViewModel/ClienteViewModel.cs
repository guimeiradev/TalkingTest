using Microsoft.AspNetCore.Components.Web;

namespace CadastroClienteEPedido.ViewModel;

public class ClienteViewModel
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public bool Ativo { get; set; }
}