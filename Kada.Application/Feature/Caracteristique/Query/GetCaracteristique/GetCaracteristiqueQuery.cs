using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Caracteristique.Query.GetCaracteristique
{
    public class GetCaracteristiqueQuery : IRequest<SearchResult<CaracteristiqueDTO>>
    {
        public SearchDTO Search { get; set; }
    }
}
