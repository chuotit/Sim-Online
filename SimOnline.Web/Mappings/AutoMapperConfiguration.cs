using AutoMapper;
using SimOnline.Model.Models;
using SimOnline.Web.Models;

namespace SimOnline.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<SimNetwork, SimNetworkViewModel>();
            Mapper.CreateMap<FirstNumber, FirstNumberViewModel>();
            Mapper.CreateMap<SimNumber, SimNumberViewModel>();
            Mapper.CreateMap<Consigner, ConsignerViewModel>();
            Mapper.CreateMap<ConsignerLevel, SimNumberViewModel>();
        }

    }
}