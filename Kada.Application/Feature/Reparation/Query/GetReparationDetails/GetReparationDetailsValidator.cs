using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Reparation.Query.GetReparationDetails
{
    public class GetReparationDetailsValidator : AbstractValidator<GetReparationDetailsQuery>
    {
        private readonly IReparationRepository _reparationRepository;
        public GetReparationDetailsValidator(IReparationRepository reparationRepository)
        {
            _reparationRepository = reparationRepository;

            RuleFor(p => p)
                .NotNull()
                .MustAsync(ReparationExist).WithMessage("This Reparation doesn't exist");
        }

        public async Task<bool> ReparationExist(GetReparationDetailsQuery command, CancellationToken token)
        {
            return await _reparationRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
