using MediatR;

namespace Kada.Application.Feature.Etat.Command.UpdateEtat
{
    public class UpdateEtatCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
    }
}
