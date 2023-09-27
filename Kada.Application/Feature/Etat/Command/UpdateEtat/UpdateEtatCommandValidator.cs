using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Etat.Command.UpdateEtat
{
    public class UpdateEtatCommandValidator:AbstractValidator<UpdateEtatCommand>
    {
        private readonly IEtatRepository _etatRepository;
        public UpdateEtatCommandValidator(IEtatRepository etatRepository)
        {
            _etatRepository = etatRepository;
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(IsExist).WithMessage("This Etat Not exist");
        }

        public async Task<bool> IsExist(Guid id, CancellationToken token)
        {
            return await _etatRepository.ExistsAsync(t => t.Id == id);
        }
    }
}
