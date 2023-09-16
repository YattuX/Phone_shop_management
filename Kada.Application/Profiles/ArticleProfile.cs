using AutoMapper;
using Kada.Application.DTOs;
using Kada.Domain;

namespace Kada.Application.Profiles
{
    public class ArticleProfile:Profile
    {
        public ArticleProfile() 
        {
            CreateMap<ArticleDTO,Article>().ReverseMap();
        }
    }
}
