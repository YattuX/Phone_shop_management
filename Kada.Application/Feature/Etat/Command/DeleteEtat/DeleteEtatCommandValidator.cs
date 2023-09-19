using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Etat.Command.DeleteEtat
{
    public class DeleteEtatCommandValidator:AbstractValidator<DeleteEtatCommand>
    {
        private IEtatRepository _etatRepository;
        public DeleteEtatCommandValidator(IEtatRepository etatRepository)
        {
            _etatRepository = etatRepository;
            RuleFor(p => p)
                .NotNull()
                .MustAsync(EtatExist).WithMessage("This etat doesn't exist");
        }
        
        public async Task<bool> EtatExist(DeleteEtatCommand command, CancellationToken cancellationToken)
        {
            return await _etatRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
