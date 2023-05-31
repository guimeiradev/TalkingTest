using System.ComponentModel.DataAnnotations.Schema;
using CadastroClienteEPedido.Enum;

namespace CadastroClienteEPedido.Models;

public class Pedido
{
    public int Id { get; set; }
    public string Cliente { get; set; }
    public string Produto { get; set; }
    [Column("Valor_Total")]
    public decimal ValorTotal { get; set; }
    public EnumStatus Status { get; set; }
}