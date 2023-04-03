using AutoMapper;
using MStarSupply.Models.Models;
using MStarSupplyApi.Dtos;

namespace MStarSupplyApi.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Mercadoria, MercadoriaDto>().ReverseMap();
            CreateMap<Mercadoria, MercadoriaRequestDto>().ReverseMap();

            CreateMap<EntradaSaidaDto, EntradaSaida>();
            CreateMap<EntradaSaida, EntradaSaidaDto>();

            CreateMap<EntradaSaida, EntradaSaidaRequestDto>().ReverseMap();

            CreateMap<Fabricante, FabricanteDto>();
            CreateMap<Fabricante, FabricanteRequestDto>().ReverseMap();
        }
    }
}
