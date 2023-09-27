using AutoMapper;
using Kada.Application.DTOs;
using Kada.Application.Feature.Article.Command.CreateArticle;
using Kada.Application.Feature.Article.Command.UpdateArticle;
using Kada.Domain;

namespace Kada.Application.Profiles
{
    public class ArticleProfile:Profile
    {
        public ArticleProfile() 
        {
            CreateMap<ArticleDTO,Article>().ReverseMap();
            CreateMap<CreateArticleCommand,Article>().ReverseMap();
            CreateMap<UpdateArticleCommand,Article>().ReverseMap();
        }
    }
}
