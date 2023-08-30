using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using Kada.Domain;
using MediatR;
using Kada.Application.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Client_.Command.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Guid>
    {
        private IClientRepository _clientRepository;
        private IMapper _map;
        public CreateClientCommandHandler(IClientRepository clientRepository, IMapper map) 
        {
            _clientRepository = clientRepository;
            _map = map;
        }
        public async Task<Guid> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateClientCommandValidator();
            var resultValidator = await validator.ValidateAsync(request);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException("Client Invalid", resultValidator);
            }
            var client = _map.Map<Client>(request);
            var identifiant = Utils.GenerateRandomIdentifier("CLT-");
            var quit = 0;
            while (await _clientRepository.ExistsAsync(x => x.Identifiant == identifiant))
            {
                identifiant = Utils.GenerateRandomIdentifier("CLT-");
                quit++;
                if (quit > 10000) 
                {
                    throw new BadRequestException("Identifiant Client already exist, please try again");
                } 
            }
            client.Identifiant = identifiant;
            await _clientRepository.CreateAsync(client);
            return client.Id;
        }
    }
}
