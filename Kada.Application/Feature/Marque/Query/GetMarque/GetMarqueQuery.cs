using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Marque.Query.GetMarque
{
    public class GetMarqueQuery : IRequest<SearchResult<MarqueDTO>>
    {
        public SearchDTO Search { get; set; }
    }
}
