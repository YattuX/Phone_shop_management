using FluentValidation;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Feature.Fournisseur.Command.DeleteFournisseur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Fournisseur.Command.UpdateFournisseur
{
    public class UpdateFournisseurCommandValidator : AbstractValidator<UpdateFournisseurCommand>
    {
        IFournisseurRepository _fournisseurRepository;
        public UpdateFournisseurCommandValidator(IFournisseurRepository fournisseurRepository) 
        {
            _fournisseurRepository = fournisseurRepository;

            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(FournisseurExist).WithMessage("This provider doesn't exist");
            RuleFor(p => p.Name)
               .NotEmpty()
               .NotNull()
               .MinimumLength(2).WithMessage("{PropertyName} muster be greather than 1 character");
            RuleFor(p => p.LastName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
            RuleFor(p => p.WhatsappNumber)
                .NotEmpty()
                .NotNull()
                .MaximumLength(9).WithMessage("{PropertyName} must be fewer than 9 characters");
            RuleFor(p => p.Email)
               .NotEmpty()
               .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
        }

        public async Task<bool> FournisseurExist(Guid Id, CancellationToken token)
        {
            return await _fournisseurRepository.ExistsAsync(x => x.Id == Id);
        }
    }
}
