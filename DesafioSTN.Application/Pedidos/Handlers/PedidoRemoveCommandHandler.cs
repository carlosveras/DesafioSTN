using DesafioSTN.Application.Pedidos.Commands;
using DesafioSTN.Domain.Entities;
using DesafioSTN.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioSTN.Application.Pedidos.Handlers
{
    public class PedidoRemoveCommandHandler : IRequestHandler<PedidoRemoveCommand, Pedido>
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoRemoveCommandHandler(IPedidoRepository pedidoRepository)
        {
			_pedidoRepository = pedidoRepository ??
            throw new ArgumentNullException(nameof(pedidoRepository));
        }

        public async Task<Pedido> Handle(PedidoRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(request.Id);

            if (pedido == null)
                throw new ApplicationException($"Pedido não encontrado.");
            else
            {
                return await _pedidoRepository.RemoveAsync(pedido);
            }
        }
    }
}
