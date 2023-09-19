using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Particularite.Command.UpdateParticularite
{
    public class UpdateParticulariteCommandValidator:AbstractValidator<UpdateParticulariteCommand>
    {
        private readonly IParticulariteRepository _particulariteRepository;
        public UpdateParticulariteCommandValidator(IParticulariteRepository particulariteRepository)
        {
            _particulariteRepository = particulariteRepository;
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(IsExist).WithMessage("This Particularite Not exist");
        }

        public async Task<bool> IsExist(Guid id, CancellationToken token)
        {
            return await _particulariteRepository.ExistsAsync(t => t.Id == id);
        }
    }
}
