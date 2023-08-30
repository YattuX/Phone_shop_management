using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Client_.Command.DeleteClient
{
    public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Unit>
    {
        private IClientRepository _clientReposipositroy;
        public DeleteClientCommandHandler( IClientRepository clientRepository) 
        {
           _clientReposipositroy = clientRepository;
        }

        public async Task<Unit> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteClientCommandValidator(_clientReposipositroy);
            var resultValidator = await validator.ValidateAsync(request);
            if(resultValidator.Errors.Any()) 
            {
                throw new BadRequestException("Invalid client Id", resultValidator);
            }
            var client = await _clientReposipositroy.GetByIdAsync(request.Id);
            await _clientReposipositroy.DeleteAsync(client);
            return Unit.Value;
        }
    }
}
