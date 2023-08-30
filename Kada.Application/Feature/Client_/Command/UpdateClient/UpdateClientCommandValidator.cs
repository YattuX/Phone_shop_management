using FluentValidation;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Feature.Client_.Command.DeleteClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Client_.Command.UpdateClient
{
    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        private IClientRepository _clientRepository;
        public UpdateClientCommandValidator(IClientRepository clientRepository) 
        {
            _clientRepository = clientRepository;

            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(ClientExist);
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
            RuleFor(p => p.LastName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
            RuleFor(p => p.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .MaximumLength(9).WithMessage("{PropertyName} must be fewer than 9 characters");
            RuleFor(p => p.WhatsappNumber)
                .NotEmpty()
                .NotNull()
                .MaximumLength(9).WithMessage("{PropertyName} must be fewer than 9 characters");
            RuleFor(p => p.Adress)
               .NotEmpty()
               .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
        }

        public async Task<bool> ClientExist(Guid id , CancellationToken token)
        {
            return await _clientRepository.ExistsAsync(x => x.Id == id);
        }
    }
}
