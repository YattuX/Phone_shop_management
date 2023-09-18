using MediatR;

namespace Kada.Application.Feature.Type_.Command.DeleteType
{
    public class DeleteTypeCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
