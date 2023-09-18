using AutoMapper;
using Kada.Application.DTOs;
using Kada.Application.Feature.Type_.Command.CreateType;
using Kada.Application.Feature.Type_.Command.UpdateType;
using Kada.Domain;

namespace Kada.Application.Profiles
{
    public class TypeProfile: Profile
    {
        public TypeProfile() 
        {
            CreateMap<TypeDTO, Type_>().ReverseMap();
            CreateMap<CreateTypeCommand, Type_>().ReverseMap();
            CreateMap<UpdateTypeCommand, Type_>().ReverseMap();
        }
    }
}
