using AutoMapper;
using DesafioSTN.Application.DTOs;
using DesafioSTN.Application.Interfaces;
using DesafioSTN.Domain.Entities;
using DesafioSTN.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioSTN.Application.Services
{
    public class ItemPedidoService : IItemPedidoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IItemPedidoRepository _itemPedidoRepository;

        public ItemPedidoService(IMapper mapper, IMediator mediator, IItemPedidoRepository itemPedidoRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _itemPedidoRepository = itemPedidoRepository;
        }

        public async Task<IEnumerable<ItemPedidoDTO>> GetItensPedido()
        {
            var itemPedidosEntity = await _itemPedidoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ItemPedidoDTO>>(itemPedidosEntity);
        }

        public async Task<ItemPedidoDTO> GetItensPedidoById(int id)
        {
            var itemPedidoEntity = await _itemPedidoRepository.GetByIdAsync(id);
            return _mapper.Map<ItemPedidoDTO>(itemPedidoEntity);
        }

        public async Task Add(ItemPedidoDTO itemPedidoDTO)
        {
            var itemPedidoEntity = _mapper.Map<ItemPedido>(itemPedidoDTO);
            await _itemPedidoRepository.CreateAsync(itemPedidoEntity);
        }

        public async Task Update(ItemPedidoDTO itemPedidoDTO)
        {
            var itemPedidoEntity = _mapper.Map<ItemPedido>(itemPedidoDTO);
            await _itemPedidoRepository.UpdateAsync(itemPedidoEntity);
        }

        public async Task Remove(int id)
        {
            var itemPedidoEntity = await _itemPedidoRepository.GetByIdAsync(id);
            await _itemPedidoRepository.RemoveAsync(itemPedidoEntity);
        }

    }
}