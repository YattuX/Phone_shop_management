using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Couleur.Query.GetCouleur
{
    public class GetCouleurQuery : IRequest<SearchResult<CouleurDTO>>
    {
        public SearchDTO Search { get; set; }
    }
}
