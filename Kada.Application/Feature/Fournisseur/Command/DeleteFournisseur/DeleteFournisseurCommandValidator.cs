using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Fournisseur.Command.DeleteFournisseur
{
    public class DeleteFournisseurCommandValidator : AbstractValidator<DeleteFournisseurCommand>
    {
        private IFournisseurRepository _fournisseurRepository;
        public DeleteFournisseurCommandValidator(IFournisseurRepository fournisseurRepository)
        {
            _fournisseurRepository = fournisseurRepository;

            RuleFor(p => p)
                .NotNull()
                .MustAsync(FournisseurExist).WithMessage("This provider doesn't exist");
        }

        public async Task<bool> FournisseurExist(DeleteFournisseurCommand command, CancellationToken token)
        {
            return await _fournisseurRepository.ExistsAsync(x => x.Id == command.Id);
        }

    }
}
