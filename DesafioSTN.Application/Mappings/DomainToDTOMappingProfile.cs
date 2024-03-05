using AutoMapper;
using DesafioSTN.Application.DTOs;
using DesafioSTN.Domain.Entities;

namespace DesafioSTN.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();

            CreateMap<Pedido, PedidoDTO>().ReverseMap();

            CreateMap<ItemPedido, ItemPedidoDTO>().ReverseMap();

            CreateMap<Pedido, PedidoCreateDTO>().ReverseMap();

            CreateMap<Pedido, PedidoCreatedDTO>().ReverseMap();
        }
    }
}
