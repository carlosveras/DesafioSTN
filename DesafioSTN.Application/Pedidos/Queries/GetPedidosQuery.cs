using DesafioSTN.Application.DTOs;
using DesafioSTN.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace DesafioSTN.Application.Pedidos.Queries
{
    public class GetPedidosQuery : IRequest<IEnumerable<Pedido>>
    {
    }
}
