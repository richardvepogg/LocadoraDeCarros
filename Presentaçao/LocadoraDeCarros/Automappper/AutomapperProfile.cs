using AutoMapper;
using Dados.Models;
using LocadoraDeCarros.Models.ModeloDados;
using Negocio.Models;

namespace LocadoraDeCarros.Automappper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Cliente, ClienteDataModel>().ReverseMap();
        }

    }
}
