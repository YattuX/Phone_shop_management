using MediatR;

namespace Kada.Application.Feature.Stockage.Command.CreateStockage
{
    public class CreateStockageCommand:IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
