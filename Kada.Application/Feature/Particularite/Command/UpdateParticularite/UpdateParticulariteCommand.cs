using MediatR;

namespace Kada.Application.Feature.Particularite.Command.UpdateParticularite
{
    public class UpdateParticulariteCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}
