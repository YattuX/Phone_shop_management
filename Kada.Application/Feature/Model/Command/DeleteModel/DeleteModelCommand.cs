using MediatR;

namespace Kada.Application.Feature.Model.Command.DeleteModel
{
    public class DeleteModelCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
