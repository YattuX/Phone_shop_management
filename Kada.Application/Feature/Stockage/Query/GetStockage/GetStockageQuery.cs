using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Stockage.Query.GetStockage
{
    public class GetStockageQuery : IRequest<SearchResult<StockageDTO>>
    {
        public SearchDTO Search { get; set; }
    }
}
