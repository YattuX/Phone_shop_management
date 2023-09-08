using FluentValidation;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Feature.Client_.Command.CreateClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Fournisseur.Command.CreateFournisseur
{
    public class CreateFournisseurCommandValidator : AbstractValidator<CreateFournisseurCommand>
    {
        IFournisseurRepository _fournisseurRepository;
        public CreateFournisseurCommandValidator(IFournisseurRepository fournisseurRepository)
        {
            _fournisseurRepository = fournisseurRepository;

            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
            RuleFor(p => p.LastName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
            RuleFor(p => p.WhatsappNumber)
                .NotEmpty()
                .NotNull()
                .MustAsync(doesWhatsappNumberExist).WithMessage("This whatsapp number already exist")
                .MaximumLength(20).WithMessage("{PropertyName} must be fewer than 9 characters");
            RuleFor(p => p.Email)
               .NotEmpty()
               .NotNull()
               .MustAsync(doesEmailExist).WithMessage("This email already exist")
               .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
        }

        public async Task<bool> doesWhatsappNumberExist(string whatsappNumber, CancellationToken token)
        {
            return await _fournisseurRepository.ExistsAsync(x => x.WhatsappNumber == whatsappNumber);
        }

        public async Task<bool> doesEmailExist(string email, CancellationToken token)
        {
            return await _fournisseurRepository.ExistsAsync(x => x.Email == email);
        }
    }
}
