using AutoMapper;
using Kada.Application.DTOs;
using Kada.Application.Feature.Couleur.Command.CreateCouleur;
using Kada.Application.Feature.Couleur.Command.UpdateCouleur;
using Kada.Domain;

namespace Kada.Application.Profiles
{
    public class CouleurProfile:Profile
    {
        public CouleurProfile() 
        { 
            CreateMap<CouleurDTO, Couleur>().ReverseMap();
            CreateMap<CreateCouleurCommand, Couleur>().ReverseMap();
            CreateMap<UpdateCouleurCommand, Couleur>().ReverseMap();
        }
    }
}
