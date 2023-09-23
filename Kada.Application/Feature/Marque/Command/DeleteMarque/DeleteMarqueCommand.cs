using MediatR;

namespace Kada.Application.Feature.Marque.Command.DeleteMarque
{
    public class DeleteMarqueCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
