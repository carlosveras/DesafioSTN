using DesafioSTN.Application.DTOs;
using DesafioSTN.Application.Pedidos.Queries;
using DesafioSTN.Domain.Entities;
using DesafioSTN.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioSTN.Application.Pedidos.Handlers
{
    public class GetPedidosQueryHandler : IRequestHandler<GetPedidosQuery, IEnumerable<Pedido>>
    {
        private readonly IPedidoRepository _pedidoRepository;

        public GetPedidosQueryHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<IEnumerable<Pedido>> Handle(GetPedidosQuery request, 
            CancellationToken cancellationToken)
        {
            return await _pedidoRepository.GetAllAsync();
        }
    }
}
