using MediatR;

namespace Kada.Application.Feature.Article.Command.DeleteArticle
{
    public class DeleteArticleCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
