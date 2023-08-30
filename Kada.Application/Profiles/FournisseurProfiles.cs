using AutoMapper;
using Kada.Application.DTOs;
using Kada.Application.Feature.Fournisseur.Command.CreateFournisseur;
using Kada.Application.Feature.Fournisseur.Command.UpdateFournisseur;
using Kada.Domain;

namespace Kada.Application.Profiles
{
    public class FournisseurProfiles : Profile
    {
        public FournisseurProfiles() 
        {
            CreateMap<FournisseurDto, Fournisseur>().ReverseMap();
            CreateMap<CreateFournisseurCommand, Fournisseur>().ReverseMap();
            CreateMap<UpdateFournisseurCommand, Fournisseur>().ReverseMap();
        }
    }
}
