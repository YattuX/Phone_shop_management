using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Particularite.Query.GetParticularite
{
    public class GetParticulariteQuery : IRequest<SearchResult<ParticulariteDTO>>
    {
        public SearchDTO Search { get; set; }
    }
}
