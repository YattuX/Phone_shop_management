using Kada.Application.DTOs;
using MediatR;

namespace Kada.Application.Feature.Article.Query.GetArticleDetails
{
    public class GetArticleDetailsQuery: IRequest<ArticleDTO>
    {
        public Guid Id { get; set; }
    }
}
