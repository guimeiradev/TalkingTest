using System.ComponentModel.DataAnnotations.Schema;
using CadastroClienteEPedido.Enum;
using CadastroClienteEPedido.Models;

namespace CadastroClienteEPedido.ViewModel;

public class PedidoViewModel
{
    public int Id { get; set; }
    public string Cliente { get; set; }
    public string Produto { get; set; }
    public decimal ValorTotal { get; set; }
    public EnumStatus Status { get; set; }
}