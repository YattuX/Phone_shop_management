using FluentValidation;
using Kada.Application.Contracts.Pesistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Client_.Command.DeleteClient
{
    public class DeleteClientCommandValidator : AbstractValidator<DeleteClientCommand>
    {
        private IClientRepository _clientRepository;
        public DeleteClientCommandValidator(IClientRepository clientRepository) 
        {
            _clientRepository = clientRepository;

            RuleFor(p => p)
                .NotNull()
                .MustAsync(ClientExist).WithMessage("This Client doesn't exist");
        }

        public async Task<bool> ClientExist(DeleteClientCommand command, CancellationToken token)
        {
            return await _clientRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
