using Kada.Application.DTOs;
using MediatR;

namespace Kada.Application.Feature.Stockage.Query.GetStockageDetails
{
    public class GetStockageDetailsQuery: IRequest<StockageDTO>
    {
        public Guid Id { get; set; }
    }
}
