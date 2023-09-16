using MediatR;

namespace Kada.Application.Feature.TypeArticle.Command.CreateTypeArticle
{
    public class CreateTypeArticleCommand:IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
