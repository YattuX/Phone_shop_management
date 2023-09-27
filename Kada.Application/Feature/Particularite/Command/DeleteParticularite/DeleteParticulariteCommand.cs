using MediatR;

namespace Kada.Application.Feature.Particularite.Command.DeleteParticularite
{
    public class DeleteParticulariteCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
