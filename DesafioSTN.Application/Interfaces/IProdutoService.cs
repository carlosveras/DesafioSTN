using DesafioSTN.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioSTN.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDTO>> GetProdutos();

        Task<ProdutoDTO> GetProdutoById(int id);

        Task Add(ProdutoDTO produtoDTO);

        Task Update(ProdutoDTO produtoDTO);

        Task Remove(int id);
    }
}
