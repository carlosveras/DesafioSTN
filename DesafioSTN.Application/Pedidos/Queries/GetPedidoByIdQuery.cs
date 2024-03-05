using DesafioSTN.Domain.Entities;
using MediatR;

namespace DesafioSTN.Application.Pedidos.Queries
{
    public class GetPedidoByIdQuery : IRequest<Pedido>
    {
        public int Id { get; set; }
        public GetPedidoByIdQuery(int id)
        {
            Id = id;
        }
    }
}
