using DesafioSTN.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioSTN.Application.Interfaces
{
    public interface IItemPedidoService
    {
        Task <IEnumerable<ItemPedidoDTO>> GetItensPedido();

        Task<ItemPedidoDTO> GetItensPedidoById(int id);

        Task Add(ItemPedidoDTO itemPedidoDTO);

        Task Update(ItemPedidoDTO itemPedidoDTO);

        Task Remove(int id);
    }
}
