using DesafioSTN.Domain.Entities;
using DesafioSTN.Domain.Interfaces;
using DesafioSTN.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioSTN.Infra.Data.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _pedidoContext;
        public PedidoRepository(ApplicationDbContext pedidoContext)
        {
            _pedidoContext = pedidoContext;
        }

        public async Task<Pedido> CreateAsync(Pedido pedido)
        {
            _pedidoContext.Add(pedido);
            await _pedidoContext.SaveChangesAsync();
            return pedido;
        }

        public async Task<IEnumerable<Pedido>> GetAllAsync()
        {
            return await _pedidoContext.Pedidos.Include(ip => ip.ItensPedido)
                                       .ToListAsync();
        }

        public async Task<Pedido> GetByIdAsync(int id)
        {
            return await _pedidoContext.Pedidos.Include(ip => ip.ItensPedido)
                                               .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Pedido> RemoveAsync(Pedido pedido)
        {
            _pedidoContext.Remove(pedido);
            await _pedidoContext.SaveChangesAsync();
            return pedido;
        }

        public async Task<Pedido> UpdateAsync(Pedido pedido)
        {
            _pedidoContext.Update(pedido);
            await _pedidoContext.SaveChangesAsync();
            return pedido;
        }
    }
}
