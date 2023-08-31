using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Client_.Query.GetClients
{
    public class GetClientsQuery : IRequest<SearchResult<ClientDto>>
    {
        public SearchDTO Search { get; set; }
    }
}
