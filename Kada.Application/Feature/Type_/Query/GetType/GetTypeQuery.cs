using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Type_.Query.GetType
{
    public class GetTypeQuery : IRequest<SearchResult<TypeDTO>>
    {
        public SearchDTO Search { get; set; }
    }
}
