using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using Kada.Domain;
using MediatR;

namespace Kada.Application.Feature.Client_.Query.GetClients
{
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, SearchResult<ClientDto>>
    {
        private readonly IClientRepository _clientRepository;
        public GetClientsQueryHandler(IClientRepository clientRepository) 
        {
            _clientRepository = clientRepository;
        }

        public async Task<SearchResult<ClientDto>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            return await GetClientListPageAsync(request.Search.PageIndex, request.Search.PageSize, request.Search.Filters);
        }

        public async Task<SearchResult<ClientDto>> GetClientListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters)
        {
            var filteredRequest = GetFilteredQuery(filters);
            var filteredClient = (pageIndex == -1) ? filteredRequest.ToList() : filteredRequest.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var rows = new List<ClientDto>();

            foreach (Client client in filteredClient)
            {
                rows.Add(new ClientDto
                {
                    Identifiant = client.Identifiant,
                    Name = client.Name,
                    LastName = client.LastName,
                    Adress = client.Adress,
                    PhoneNumber = client.PhoneNumber,
                    WhatsappNumber = client.WhatsappNumber,
                    IsClientEnGros = client.IsClientEnGros
                });
            }

            return new SearchResult<ClientDto>
            {
                Page = pageIndex,
                CountPerPage = pageSize,
                TotalCount = filteredRequest.Count(),
                Results = rows
            };
        }

        public IQueryable<Client> GetFilteredQuery(Dictionary<string, string> filter)
        {
            IQueryable<Client> clientQuery = _clientRepository.GetQuery();

            foreach (var key in filter.Keys)
            {
                if (string.IsNullOrEmpty(filter[key]))
                {
                    continue;
                }

                switch (key)
                {
                    case "name":
                        clientQuery = _clientRepository.FilterQuery(clientQuery, x => x.Name.StartsWith(filter[key]));
                        break;
                    case "lastName":
                        clientQuery = _clientRepository.FilterQuery(clientQuery, x => x.LastName.StartsWith(filter[key]));
                        break;
                    case "whatsappNumber":
                        clientQuery = _clientRepository.FilterQuery(clientQuery, x => x.WhatsappNumber.StartsWith(filter[key]));
                        break;
                    case "adress":
                        clientQuery = _clientRepository.FilterQuery(clientQuery, x => x.Adress.StartsWith(filter[key]));
                        break;
                    case "identifiant":
                        clientQuery = _clientRepository.FilterQuery(clientQuery, x => x.Identifiant.StartsWith(filter[key]));
                        break;
                }
            }
            return clientQuery;
        }
        
    }
}
