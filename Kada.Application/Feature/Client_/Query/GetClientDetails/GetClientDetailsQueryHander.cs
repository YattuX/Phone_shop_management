using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Client_.Query.GetClientDetails
{
    public class GetClientDetailsQueryHander : IRequestHandler<GetClientDetailsQuery, ClientDto>
    {
        private IClientRepository _clientRepository;
        private IMapper _map;
        public GetClientDetailsQueryHander(IClientRepository clientRepository, IMapper map) 
        {
            _clientRepository = clientRepository;
            _map = map;
        }
        public async Task<ClientDto> Handle(GetClientDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetClientDetailsQueryValidator(_clientRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException("This client does not exist", resultValidator);
            }

            var client = await _clientRepository.GetByIdAsync(request.Id);
            return _map.Map<ClientDto>(client);
        }
    }
}
