using Kada.Domain;
using MediatR;

namespace Kada.Application.Feature.Marque.Command.CreateMarque
{
    public class CreateMarqueCommand:IRequest<Guid>
    {
        public string Name { get; set; }
        public Guid TypeArticleId { get; set; }
    }
}
