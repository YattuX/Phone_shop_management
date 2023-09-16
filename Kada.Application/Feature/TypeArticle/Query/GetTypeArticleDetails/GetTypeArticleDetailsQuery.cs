using Kada.Application.DTOs;
using MediatR;

namespace Kada.Application.Feature.TypeArticle.Query.GetTypeArticleDetails
{
    public class GetTypeArticleDetailsQuery: IRequest<TypeArticleDTO>
    {
        public Guid Id { get; set; }
    }
}
