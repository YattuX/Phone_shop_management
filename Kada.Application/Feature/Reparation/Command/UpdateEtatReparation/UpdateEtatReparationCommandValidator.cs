using FluentValidation;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Feature.Reparation.Command.DeleteReparation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Reparation.Command.UpdateEtatReparation
{
    public class UpdateEtatReparationCommandValidator : AbstractValidator<UpdateEtatReparationCommand>
    {
        private IReparationRepository _reparationRepository;
        public UpdateEtatReparationCommandValidator(IReparationRepository reparationRepository)
        {
            _reparationRepository = reparationRepository;
            RuleFor(p => p)
                .NotNull()
                .NotEmpty()
                .MustAsync(ReparationExist).WithMessage("This reparation doesn't exist");

            RuleFor(p => p)
                .MustAsync(IsRestituee)
                .WithMessage("This article has already been returned")
                .WhenAsync(async (p, canc) =>
                {
                    if (p == null)
                        return false;

                    return await ReparationExist(p, canc);
                });
        }

        public async Task<bool> ReparationExist(UpdateEtatReparationCommand command, CancellationToken cancellationToken)
        {
            return await _reparationRepository.ExistsAsync(x => x.Id == command.Id);
        }

        public async Task<bool> IsRestituee(UpdateEtatReparationCommand command, CancellationToken cancellationToken)
        {
            var reparation = await _reparationRepository.GetByIdAsync(command.Id);
            if(reparation.EtatReparation == Domain.Enums.EtatReparation.Restituee)
            {
                return false;
            }
            return true;
        }
    }
}
