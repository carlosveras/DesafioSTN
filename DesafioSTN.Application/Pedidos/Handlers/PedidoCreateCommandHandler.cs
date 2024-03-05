using DesafioSTN.Application.Pedidos.Commands;
using DesafioSTN.Domain.Entities;
using DesafioSTN.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DesafioSTN.Application.Pedidos.Handlers
{
    public class PedidoCreateCommandHandler : IRequestHandler<PedidoCreateCommand, Pedido>
    {
        private readonly IPedidoRepository _pedidoRepository;
        public PedidoCreateCommandHandler(IPedidoRepository contaCorrenteRepository)
        {
			_pedidoRepository = contaCorrenteRepository;
        }
        public async Task<Pedido> Handle(PedidoCreateCommand request, CancellationToken cancellationToken)
        {
            var pedido = new Pedido(request.NomeCliente, request.EmailCliente, request.Pago);

            if (pedido == null)
                throw new ApplicationException($"Erro ao criar o pedido.");

            return await _pedidoRepository.CreateAsync(pedido);
        }

    }
}
