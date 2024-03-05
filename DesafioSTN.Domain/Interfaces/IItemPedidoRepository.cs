using DesafioSTN.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioSTN.Domain.Interfaces
{
    public interface IItemPedidoRepository
    {
        Task<IEnumerable<ItemPedido>> GetAllAsync();

        Task<ItemPedido> GetByIdAsync(int id);

        Task<ItemPedido> CreateAsync(ItemPedido itemPedido);

        Task<ItemPedido> UpdateAsync(ItemPedido itemPedido);

        Task<ItemPedido> RemoveAsync(ItemPedido itemPedido);

    }
}
