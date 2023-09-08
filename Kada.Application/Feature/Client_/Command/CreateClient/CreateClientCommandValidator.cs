using FluentValidation;
using Kada.Application.Contracts.Pesistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Client_.Command.CreateClient
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        IClientRepository _clientRepository;
        public CreateClientCommandValidator(IClientRepository clientRepository) 
        { 
            _clientRepository= clientRepository;

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
                .MustAsync(doesPhoneNumberExist).WithMessage("This phone number already exist")
                .MaximumLength(20).WithMessage("{PropertyName} must be fewer than 9 characters");
            RuleFor(p => p.WhatsappNumber)
                .NotEmpty()
                .NotNull()
                .MustAsync(doesWhatsappNumberExist).WithMessage("This whatsapp number already exist")
                .MaximumLength(20).WithMessage("{PropertyName} must be fewer than 9 characters");
            RuleFor(p => p.Adress)
               .NotEmpty()
               .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
        }

        public async Task<bool> doesPhoneNumberExist(string phoneNumber, CancellationToken token)
        {
            return await _clientRepository.ExistsAsync(x => x.PhoneNumber== phoneNumber);
        }
        public async Task<bool> doesWhatsappNumberExist(string whatsappNumber, CancellationToken token)
        {
            return await _clientRepository.ExistsAsync(x => x.WhatsappNumber == whatsappNumber);
        }
    }
}
