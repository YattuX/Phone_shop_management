using MediatR;

namespace Kada.Application.Feature.Etat.Command.CreateEtat
{
    public class CreateEtatCommand:IRequest<Guid>
    {
        public string Content { get; set; }
    }
}
