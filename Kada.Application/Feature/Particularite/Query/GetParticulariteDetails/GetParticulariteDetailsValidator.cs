using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Particularite.Query.GetParticulariteDetails
{
    public class GetParticulariteDetailsValidator : AbstractValidator<GetParticulariteDetailsQuery>
    {
        private readonly IParticulariteRepository _particulariteRepository;
        public GetParticulariteDetailsValidator( IParticulariteRepository particulariteRepository)
        {
            _particulariteRepository = particulariteRepository;

            RuleFor(p => p)
                .NotNull()
                .MustAsync(ParticulariteExist).WithMessage("This Particularite doesn't exist");
        }

        public async Task<bool> ParticulariteExist(GetParticulariteDetailsQuery command, CancellationToken token)
        {
            return await _particulariteRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
