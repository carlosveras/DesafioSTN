using DesafioSTN.Domain.Entities;
using DesafioSTN.Domain.Interfaces;
using DesafioSTN.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioSTN.Infra.Data.Repositories
{

    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _produtoContext;
        public ProdutoRepository(ApplicationDbContext produtoContext)
        {
            _produtoContext = produtoContext;
        }

        public async Task<Produto> Add(Produto produto)
        {
            _produtoContext.Add(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }

        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            return await _produtoContext.Produtos.ToListAsync();
        }

        public async Task<Produto> GetProdutoById(int id)
        {
            return await _produtoContext.Produtos.FindAsync(id);
        }

        public async Task<Produto> Remove(Produto produto)
        {
            _produtoContext.Remove(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> Update(Produto produto)
        {
            _produtoContext.Update(produto);
            await _produtoContext.SaveChangesAsync();
            return produto;
        }
    }
}
