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

            Mapper.CreateMap<SimStore, SimStoreViewModel>();

            Mapper.CreateMap<SimStore, SimStoreAddViewModel>();

            Mapper.CreateMap<Agent, AgentViewModel>();

            Mapper.CreateMap<AgentLevel, AgentLevelViewModel>();

            Mapper.CreateMap<AppGroup, AppGroupViewModel>();

            Mapper.CreateMap<AppRole, AppRoleViewModel>();

            Mapper.CreateMap<AppUser, AppUserViewModel>();
        }

    }
}