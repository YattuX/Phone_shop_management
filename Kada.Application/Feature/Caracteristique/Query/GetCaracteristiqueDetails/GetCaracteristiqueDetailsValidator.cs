using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Caracteristique.Query.GetCaracteristiqueDetails
{
    public class GetCaracteristiqueDetailsValidator : AbstractValidator<GetCaracteristiqueDetailsQuery>
    {
        private readonly ICaracteristiqueRepository _caracteristiqueRepository;
        public GetCaracteristiqueDetailsValidator( ICaracteristiqueRepository caracteristiqueRepository)
        {
            _caracteristiqueRepository = caracteristiqueRepository;

            RuleFor(p => p)
                .NotNull()
                .NotEmpty()
                .MustAsync(CaracteristiqueExist).WithMessage("This Caracteristique doesn't exist");
        }

        public async Task<bool> CaracteristiqueExist(GetCaracteristiqueDetailsQuery command, CancellationToken token)
        {
            return await _caracteristiqueRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
