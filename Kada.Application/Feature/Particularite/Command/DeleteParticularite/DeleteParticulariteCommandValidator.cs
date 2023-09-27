using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Particularite.Command.DeleteParticularite
{
    public class DeleteParticulariteCommandValidator:AbstractValidator<DeleteParticulariteCommand>
    {
        private IParticulariteRepository _particulariteRepository;
        public DeleteParticulariteCommandValidator(IParticulariteRepository particulariteRepository)
        {
            _particulariteRepository = particulariteRepository;
            RuleFor(p => p)
                .NotNull()
                .MustAsync(ParticulariteExist).WithMessage("This particularite doesn't exist");
        }
        
        public async Task<bool> ParticulariteExist(DeleteParticulariteCommand command, CancellationToken cancellationToken)
        {
            return await _particulariteRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
