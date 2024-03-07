using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Stock.Query.GetStatStock
{
    public class GetStatStockQuery : IRequest<SearchResult<StateStockDTO>>
    {
        public SearchDTO Search { get; set; }
    }
}
