using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Couleur.Command.UpdateCouleur
{
    public class UpdateCouleurCommandValidator:AbstractValidator<UpdateCouleurCommand>
    {
        ICouleurRepository _couleurRepository;
        public UpdateCouleurCommandValidator(ICouleurRepository couleurRepository)
        {
            _couleurRepository = couleurRepository;
            RuleFor(p => p)
                .NotNull()
                .MustAsync(IsCouleurUnique).WithMessage("This Color Name already exist");
        }

        public async Task<bool> IsCouleurUnique(UpdateCouleurCommand couleur, CancellationToken token)
        {
            return !await _couleurRepository.ExistsAsync(t => t.Name.ToLower() == couleur.Name.ToLower() && t.Id != couleur.Id);
        }
    }
}
