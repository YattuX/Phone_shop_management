using MediatR;

namespace Kada.Application.Feature.Couleur.Command.UpdateCouleur
{
    public class UpdateCouleurCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
