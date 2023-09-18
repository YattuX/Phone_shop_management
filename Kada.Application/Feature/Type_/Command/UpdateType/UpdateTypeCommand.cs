using MediatR;

namespace Kada.Application.Feature.Type_.Command.UpdateType
{
    public class UpdateTypeCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}
