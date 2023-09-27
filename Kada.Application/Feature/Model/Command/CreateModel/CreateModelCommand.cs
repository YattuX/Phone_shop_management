using Kada.Domain;
using MediatR;

namespace Kada.Application.Feature.Model.Command.CreateModel
{
    public class CreateModelCommand:IRequest<Guid>
    {
        public string Name { get; set; }
        public Guid MarqueId { get; set; }
    }
}
