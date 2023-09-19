using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Etat.Query.GetEtat
{
    public class GetEtatQuery : IRequest<SearchResult<EtatDTO>>
    {
        public SearchDTO Search { get; set; }
    }
}
