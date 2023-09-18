using MediatR;

namespace Kada.Application.Feature.Type_.Command.CreateType
{
    public class CreateTypeCommand:IRequest<Guid>
    {
        public string Content { get; set; }
    }
}
