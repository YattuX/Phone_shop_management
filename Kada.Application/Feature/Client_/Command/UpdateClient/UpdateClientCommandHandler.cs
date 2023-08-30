using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using Kada.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Client_.Command.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Unit>
    {
        IMapper _map;
        IClientRepository _clientRepository;
        public UpdateClientCommandHandler(IClientRepository clientRepository, IMapper map) 
        {
            _clientRepository = clientRepository;
            _map = map;
        }

        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateClientCommandValidator(_clientRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException("Invalid Client", resultValidator);
            }
            var client = await _clientRepository.GetByIdAsync(request.Id);

            client.Name = request.Name;
            client.LastName = request.LastName;
            client.PhoneNumber= request.PhoneNumber;
            client.WhatsappNumber = request.WhatsappNumber;
            client.Adress = request.Adress;

            await _clientRepository.UpdateAsync(client);
            return Unit.Value;
        }
    }
}
