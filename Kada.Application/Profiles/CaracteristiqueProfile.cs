using AutoMapper;
using Kada.Application.DTOs;
using Kada.Application.Feature.Caracteristique.Command.CreateCaracteristique;
using Kada.Application.Feature.Caracteristique.Command.UpdateCaracteristique;
using Kada.Domain;

namespace Kada.Application.Profiles
{
    public class CaracteristiqueProfile:Profile
    {
        public CaracteristiqueProfile() 
        { 
            CreateMap<CaracteristiqueDTO, Caracteristique>().ReverseMap();
            CreateMap<CreateCaracteristiqueCommand, Caracteristique>().ReverseMap();
            CreateMap<UpdateCaracteristiqueCommand, Caracteristique>().ReverseMap();
        }
    }
}
