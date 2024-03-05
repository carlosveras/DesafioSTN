using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DesafioSTN.Application.DTOs
{
    public class PedidoCreatedDTO
    {
        public int Id { get; set; }

        public string NomeCliente { get; set; }

        public string EmailCliente { get; set; }

        public bool Pago { get; set; }

        public decimal ValorTotal { get; set; } = 0;
    }
}
