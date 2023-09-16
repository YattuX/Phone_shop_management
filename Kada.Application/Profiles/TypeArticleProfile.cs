using AutoMapper;
using Kada.Application.DTOs;
using Kada.Application.Feature.TypeArticle.Command.CreateTypeArticle;
using Kada.Application.Feature.TypeArticle.Command.UpdateTypeArticle;
using Kada.Domain;

namespace Kada.Application.Profiles
{
    public class TypeArticleProfile:Profile
    {
        public TypeArticleProfile() 
        { 
            CreateMap<TypeArticleDTO, TypeArticle>().ReverseMap();
            CreateMap<CreateTypeArticleCommand, TypeArticle>().ReverseMap();
            CreateMap<UpdateTypeArticleCommand, TypeArticle>().ReverseMap();
        }
    }
}
