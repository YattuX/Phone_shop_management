using MediatR;

namespace Kada.Application.Feature.Stockage.Command.UpdateStockage
{
    public class UpdateStockageCommand: IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
