using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Couleur.Command.DeleteCouleur
{
    public class DeleteCouleurCommandValidator:AbstractValidator<DeleteCouleurCommand>
    {
        private ICouleurRepository _couleurRepository;
        public DeleteCouleurCommandValidator(ICouleurRepository couleurRepository)
        {
            _couleurRepository = couleurRepository;
            RuleFor(p => p)
                .NotNull()
                .MustAsync(CouleurExist).WithMessage("This couleur type doesn't exist");
        }
        
        public async Task<bool> CouleurExist(DeleteCouleurCommand command, CancellationToken cancellationToken)
        {
            return await _couleurRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
