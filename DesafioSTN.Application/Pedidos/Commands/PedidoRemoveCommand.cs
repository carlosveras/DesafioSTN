using DesafioSTN.Domain.Entities;
using MediatR;

namespace DesafioSTN.Application.Pedidos.Commands
{
    public class PedidoRemoveCommand : IRequest<Pedido>
    {
        public int Id { get; set; }
        public PedidoRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
