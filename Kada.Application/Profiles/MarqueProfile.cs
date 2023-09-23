using AutoMapper;
using Kada.Application.DTOs;
using Kada.Application.Feature.Marque.Command.CreateMarque;
using Kada.Application.Feature.Marque.Command.UpdateMarque;
using Kada.Domain;

namespace Kada.Application.Profiles
{
    public class MarqueProfile: Profile
    {
        public MarqueProfile() 
        {
            CreateMap<MarqueDTO, Marque>().ReverseMap();
            CreateMap<CreateMarqueCommand, Marque>().ReverseMap();
            CreateMap<UpdateMarqueCommand, Marque>().ReverseMap();
        }
    }
}
