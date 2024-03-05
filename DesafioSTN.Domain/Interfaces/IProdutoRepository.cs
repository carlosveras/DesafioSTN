using DesafioSTN.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioSTN.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> GetProdutos();

        Task<Produto> GetProdutoById(int id);

        Task<Produto> Add(Produto produto);

        Task<Produto> Update(Produto produto);

        Task<Produto> Remove(Produto produto);
    }
}
