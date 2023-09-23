using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Article.Query.GetArticle
{
    public class GetArticleQuery : IRequest<SearchResult<ArticleDTO>>
    {
        public SearchDTO Search { get; set; }
    }
}
