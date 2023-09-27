using AutoMapper;
using Kada.Application.DTOs;
using Kada.Application.Feature.Etat.Command.CreateEtat;
using Kada.Application.Feature.Etat.Command.UpdateEtat;
using Kada.Domain;

namespace Kada.Application.Profiles
{
    public class EtatProfile: Profile
    {
        public EtatProfile() 
        {
            CreateMap<EtatDTO, Etat>().ReverseMap();
            CreateMap<CreateEtatCommand, Etat>().ReverseMap();
            CreateMap<UpdateEtatCommand, Etat>().ReverseMap();
        }
    }
}
