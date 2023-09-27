using MediatR;

namespace Kada.Application.Feature.Caracteristique.Command.DeleteCaracteristique
{
    public class DeleteCaracteristiqueCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
