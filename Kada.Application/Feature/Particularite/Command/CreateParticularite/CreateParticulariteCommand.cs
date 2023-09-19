using MediatR;

namespace Kada.Application.Feature.Particularite.Command.CreateParticularite
{
    public class CreateParticulariteCommand : IRequest<Guid>
    {
        public string Content { get; set; }
    }
}
