using DesafioSTN.Domain.Entities;
using DesafioSTN.Domain.Interfaces;
using DesafioSTN.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioSTN.Infra.Data.Repositories
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private readonly ApplicationDbContext _itemPedidoContext;
        public ItemPedidoRepository(ApplicationDbContext itemPedidoContext)
        {
            _itemPedidoContext = itemPedidoContext;
        }

        public async Task<ItemPedido> CreateAsync(ItemPedido itemPedido)
        {
            _itemPedidoContext.Add(itemPedido);
            await _itemPedidoContext.SaveChangesAsync();
            return itemPedido;
        }

        public async Task<IEnumerable<ItemPedido>> GetAllAsync()
        {
            return await _itemPedidoContext.ItensPedido.ToListAsync();
        }

        public async Task<ItemPedido> GetByIdAsync(int id)
        {
            return await _itemPedidoContext.ItensPedido.FindAsync(id);
        }

        public async Task<ItemPedido> RemoveAsync(ItemPedido itemPedido)
        {
            _itemPedidoContext.Remove(itemPedido);
            await _itemPedidoContext.SaveChangesAsync();
            return itemPedido;
        }

        public async Task<ItemPedido> UpdateAsync(ItemPedido itemPedido)
        {
            _itemPedidoContext.Update(itemPedido);
            await _itemPedidoContext.SaveChangesAsync();
            return itemPedido;
        }
    }
}
