using Kada.Application.Contracts.Pesistence;
using FluentValidation;

namespace Kada.Application.Feature.Couleur.Command.CreateCouleur
{
    public class CreateCouleurCommandValidator:AbstractValidator<CreateCouleurCommand>
    {
        ICouleurRepository _couleurRepository;
        public CreateCouleurCommandValidator( ICouleurRepository couleurRepository)
        {
            _couleurRepository = couleurRepository;

            RuleFor(t => t.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters")
                .MustAsync(NameIsUnique);
        }

        public async Task<bool> NameIsUnique(string Name, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(Name))
            {
                return false;
            }
            return !await _couleurRepository.ExistsAsync(t=>  t.Name.ToLower() == Name.ToLower());
        }
    }
}
