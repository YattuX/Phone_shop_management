using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Stock.Query.GetStock
{
    public class GetStockQuery : IRequest<SearchResult<StockDTO>>
    {
        public SearchDTO Search { get; set; }
    }
}
