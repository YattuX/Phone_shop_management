using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Client_.Query.GetClients
{
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, IReadOnlyList<ClientDto>>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _map;
        public GetClientsQueryHandler(IClientRepository clientRepository, IMapper map) 
        {
            _clientRepository = clientRepository;
            _map = map;
        }
        public async Task<IReadOnlyList<ClientDto>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            var clientList = await _clientRepository.GetAllAsync();
            return _map.Map<IReadOnlyList<ClientDto>>(clientList);

        }
    }
}
