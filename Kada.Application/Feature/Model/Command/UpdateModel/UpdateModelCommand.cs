using MediatR;

namespace Kada.Application.Feature.Model.Command.UpdateModel
{
    public class UpdateModelCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid MarqueId { get; set; }
    }
}
