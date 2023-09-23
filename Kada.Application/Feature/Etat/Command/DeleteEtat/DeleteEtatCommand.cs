using MediatR;

namespace Kada.Application.Feature.Etat.Command.DeleteEtat
{
    public class DeleteEtatCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
