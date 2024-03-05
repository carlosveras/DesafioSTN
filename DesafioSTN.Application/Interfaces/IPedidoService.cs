using DesafioSTN.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioSTN.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoDTO>> GetPedidos();

        Task<PedidoDTO> GetPedidoById(int id);

        Task Add(PedidoDTO pedidoDTO);

        Task <PedidoDTO> Create(PedidoCreateDTO pedidoCreateDTO);

        Task Update(PedidoUpdateDTO pedidoUpdateDTO);

        Task Remove(int id);
    }
}
