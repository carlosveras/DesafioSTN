using AutoMapper;
using DesafioSTN.Application.Pedidos.Commands;
using DesafioSTN.Application.DTOs;

namespace DesafioSTN.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<PedidoDTO, PedidoCreateCommand>();

            CreateMap<PedidoCreateDTO, PedidoCreateCommand>();

            CreateMap<PedidoDTO, PedidoUpdateCommand>();

            CreateMap<PedidoCreatedDTO, PedidoCreateCommand>();

            CreateMap<PedidoUpdateDTO, PedidoCreateCommand>();

            CreateMap<PedidoUpdateDTO, PedidoUpdateCommand>();
        }
    }
}
