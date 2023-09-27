using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Couleur.Query.GetCouleurDetails
{
    public class GetCouleurDetailsValidator : AbstractValidator<GetCouleurDetailsQuery>
    {
        private readonly ICouleurRepository _couleurRepository;
        public GetCouleurDetailsValidator( ICouleurRepository couleurRepository)
        {
            _couleurRepository = couleurRepository;

            RuleFor(p => p)
                .NotNull()
                .MustAsync(CouleurExist).WithMessage("This Couleur doesn't exist");
        }

        public async Task<bool> CouleurExist(GetCouleurDetailsQuery command, CancellationToken token)
        {
            return await _couleurRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
