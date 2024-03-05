using DesafioSTN.Domain.Entities;
using MediatR;
using System;

namespace DesafioSTN.Application.Pedidos.Commands
{
    public abstract class PedidoCommand : IRequest<Pedido>
    {
        public int Id { get; set; }

		public string NomeCliente { get;  set; }

		public string EmailCliente { get;  set; }

		public DateTime DataCriacao { get; set; } = DateTime.Now;

		public bool Pago { get; set; }

		public decimal ValorTotal { get; set;}

	}
}
