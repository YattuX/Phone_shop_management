using MediatR;

namespace Kada.Application.Feature.Marque.Command.UpdateMarque
{
    public class UpdateMarqueCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TypeArticleId { get; set; }
    }
}
