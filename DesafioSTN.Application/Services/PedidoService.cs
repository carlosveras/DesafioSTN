using AutoMapper;
using DesafioSTN.Application.DTOs;
using DesafioSTN.Application.Interfaces;
using DesafioSTN.Application.Pedidos.Commands;
using DesafioSTN.Application.Pedidos.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioSTN.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PedidoService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<PedidoDTO>> GetPedidos()
        {
            var pedidosQuery = new GetPedidosQuery();

            if (pedidosQuery == null)
                throw new Exception($"Pedidos não encontrado.");

            var result = await _mediator.Send(pedidosQuery);

            return _mapper.Map<IEnumerable<PedidoDTO>>(result);
        }

        public async Task<PedidoDTO> GetPedidoById(int id)
        {
            var pedidosByIdQuery = new GetPedidoByIdQuery(id);

            if (pedidosByIdQuery == null)
                throw new Exception($"Pedido não encontrado.");

            var result = await _mediator.Send(pedidosByIdQuery);

            return _mapper.Map<PedidoDTO>(result);
        }

        public async Task Add(PedidoDTO pedidoDTO)
        {
            var pedidoCreateCommand = _mapper.Map<PedidoCreateCommand>(pedidoDTO);
            await _mediator.Send(pedidoCreateCommand);
        }

        public async Task<PedidoDTO> Create(PedidoCreateDTO pedidoCreateDTO)
        {
            var pedidoCreateCommand = _mapper.Map<PedidoCreateCommand>(pedidoCreateDTO);
            var pedidoCreated = await _mediator.Send(pedidoCreateCommand);

            var pedido = _mapper.Map<PedidoDTO>(pedidoCreated);

            pedido.ValorTotal = pedidoCreateDTO.ValorTotal;
            return pedido;
        }

        public async Task Update(PedidoUpdateDTO pedidoUpdateDTO)
        {
            var pedidoUpdateCommand = _mapper.Map<PedidoUpdateCommand>(pedidoUpdateDTO);
            await _mediator.Send(pedidoUpdateCommand);
        }

        public async Task Remove(int id)
        {
            var pedidoRemoveCommand = new PedidoRemoveCommand(id);

            if (pedidoRemoveCommand == null)
                throw new Exception($"Pedido não encontrado.");

            await _mediator.Send(pedidoRemoveCommand);
        }

    }
}