using DesafioSTN.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioSTN.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetAllAsync();

        Task<Pedido> GetByIdAsync(int id);

        Task<Pedido> CreateAsync(Pedido pedido);

        Task<Pedido> UpdateAsync(Pedido pedido);

        Task<Pedido> RemoveAsync(Pedido pedido);

    }
}
