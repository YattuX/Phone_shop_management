using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Reparation.Command.DeleteReparation
{
    public class DeleteReparationCommandValidator : AbstractValidator<DeleteReparationCommand>
    {
        private IReparationRepository _reparationRepository;
        public DeleteReparationCommandValidator(IReparationRepository reparationRepository)
        {
            _reparationRepository = reparationRepository;
            RuleFor(p => p)
                .NotNull()
                .MustAsync(ReparationExist).WithMessage("This reparation doesn't exist");
        }

        public async Task<bool> ReparationExist(DeleteReparationCommand command, CancellationToken cancellationToken)
        {
            return await _reparationRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
