using DesafioSTN.Application.Pedidos.Queries;
using DesafioSTN.Domain.Entities;
using DesafioSTN.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioSTN.Application.Pedidos.Handlers
{
    public class GetPedidoByIdQueryHandler : IRequestHandler<GetPedidoByIdQuery, Pedido>
    {
        private readonly IPedidoRepository _pedidoRepository;
        public GetPedidoByIdQueryHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<Pedido> Handle(GetPedidoByIdQuery request,
             CancellationToken cancellationToken)
        {
            return await _pedidoRepository.GetByIdAsync(request.Id);
        }
       
    }
}
