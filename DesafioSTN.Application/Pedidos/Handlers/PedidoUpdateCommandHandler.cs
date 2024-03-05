using DesafioSTN.Application.Pedidos.Commands;
using DesafioSTN.Domain.Entities;
using DesafioSTN.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioSTN.Application.Products.Handlers
{
    public class PedidoUpdateCommandHandler : IRequestHandler<PedidoUpdateCommand, Pedido>
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoUpdateCommandHandler(IPedidoRepository pedidoRepository)
        {
			_pedidoRepository = pedidoRepository ??
            throw new ArgumentNullException(nameof(pedidoRepository));
        }

        public async Task<Pedido> Handle(PedidoUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(request.Id);

            if (pedido == null)
                throw new ApplicationException($"Entity could not be found.");
            else
            {
                pedido.Update(request.NomeCliente, request.EmailCliente, request.Pago);

                return await _pedidoRepository.UpdateAsync(pedido);
            }
        }
    }
}
