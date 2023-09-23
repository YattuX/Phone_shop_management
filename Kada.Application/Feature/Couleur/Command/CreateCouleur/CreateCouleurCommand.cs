using MediatR;

namespace Kada.Application.Feature.Couleur.Command.CreateCouleur
{
    public class CreateCouleurCommand:IRequest<Guid>
    {
        public string Name { get; set; }
        public string? CodeCouleur { get; set; }
    }
}
