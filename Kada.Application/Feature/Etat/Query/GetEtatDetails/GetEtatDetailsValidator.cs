using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Etat.Query.GetEtatDetails
{
    public class GetEtatDetailsValidator : AbstractValidator<GetEtatDetailsQuery>
    {
        private readonly IEtatRepository _etatRepository;
        public GetEtatDetailsValidator( IEtatRepository etatRepository)
        {
            _etatRepository = etatRepository;

            RuleFor(p => p)
                .NotNull()
                .MustAsync(EtatExist).WithMessage("This Etat doesn't exist");
        }

        public async Task<bool> EtatExist(GetEtatDetailsQuery command, CancellationToken token)
        {
            return await _etatRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
