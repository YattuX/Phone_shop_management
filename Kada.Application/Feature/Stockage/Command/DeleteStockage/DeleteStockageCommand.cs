using MediatR;

namespace Kada.Application.Feature.Stockage.Command.DeleteStockage
{
    public class DeleteStockageCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
