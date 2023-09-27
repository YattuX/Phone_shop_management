using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Caracteristique.Command.DeleteCaracteristique
{
    public class DeleteCaracteristiqueCommandValidator:AbstractValidator<DeleteCaracteristiqueCommand>
    {
        private ICaracteristiqueRepository _caracteristiqueRepository;
        public DeleteCaracteristiqueCommandValidator(ICaracteristiqueRepository caracteristiqueRepository)
        {
            _caracteristiqueRepository = caracteristiqueRepository;
            RuleFor(p => p)
                .NotNull()
                .MustAsync(CaracteristiqueExist).WithMessage("This caracteristique doesn't exist");
        }
        
        public async Task<bool> CaracteristiqueExist(DeleteCaracteristiqueCommand command, CancellationToken cancellationToken)
        {
            return await _caracteristiqueRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
