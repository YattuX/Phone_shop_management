using AutoMapper;
using Kada.Application.DTOs;
using Kada.Application.Feature.Reparation.Command.CreateReparation;
using Kada.Application.Feature.Reparation.Command.UpdateReparation;
using Kada.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Profiles
{
    public class ReparationProfile : Profile
    {
        public ReparationProfile()
        {
            CreateMap<Reparation, ReparationDTO>()
                .ForMember(dest => dest.ArticleName, opt => opt.MapFrom(src => src.Article != null ? src.Article.Caracteristique.Model.Name : null))
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.Name))
                .ReverseMap();
            CreateMap<CreateReparationCommand, Reparation>().ReverseMap();
            CreateMap<UpdateReparationCommand, Reparation>().ReverseMap();
        }
    }
}
