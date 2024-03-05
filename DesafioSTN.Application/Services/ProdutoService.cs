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
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IMapper mapper, IMediator mediator, IProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<ProdutoDTO>> GetProdutos()
        {
            var produtosEntity = await _produtoRepository.GetProdutos();
            return _mapper.Map<IEnumerable<ProdutoDTO>>(produtosEntity);
        }

        public async Task<ProdutoDTO> GetProdutoById(int id)
        {
            var produtoEntity = await _produtoRepository.GetProdutoById(id);
            return _mapper.Map<ProdutoDTO>(produtoEntity);
        }

        public async Task Add(ProdutoDTO produtoDTO)
        {
            var produtoEntity = _mapper.Map<Produto>(produtoDTO);
            await _produtoRepository.Add(produtoEntity);
        }

        public async Task Update(ProdutoDTO produtoDTO)
        {
            var produtoEntity = _mapper.Map<Produto>(produtoDTO);
            await _produtoRepository.Update(produtoEntity);
        }

        public async Task Remove(int id)
        {
            var produtoEntity = await _produtoRepository.GetProdutoById(id);
            await _produtoRepository.Remove(produtoEntity);
        }
    }
}