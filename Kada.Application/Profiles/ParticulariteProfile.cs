using AutoMapper;
using Kada.Application.DTOs;
using Kada.Application.Feature.Particularite.Command.CreateParticularite;
using Kada.Application.Feature.Particularite.Command.UpdateParticularite;
using Kada.Domain;

namespace Kada.Application.Profiles
{
    public class ParticulariteProfile: Profile
    {
        public ParticulariteProfile() 
        {
            CreateMap<ParticulariteDTO, Particularite>().ReverseMap();
            CreateMap<CreateParticulariteCommand, Particularite>().ReverseMap();
            CreateMap<UpdateParticulariteCommand, Particularite>().ReverseMap();
        }
    }
}
