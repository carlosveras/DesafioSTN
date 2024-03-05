using DesafioSTN.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioSTN.Application.DTOs
{
    public class ItemPedidoDTO
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que 0")]
        public int Quantidade { get;  set; }

        [Required(ErrorMessage = "O codigo do pedido é obrigatório")]
        public int IdPedido { get;  set; }

        public Pedido Pedido { get;  set; }

        public int IdProduto { get;  set; }

        [Required(ErrorMessage = "O codigo do produto é obrigatório")]
        public Produto Produto { get; set; }
    }
}
