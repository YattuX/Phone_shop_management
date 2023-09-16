using MediatR;

namespace Kada.Application.Feature.TypeArticle.Command.UpdateTypeArticle
{
    public class UpdateTypeArticleCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
