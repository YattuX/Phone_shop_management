using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Stockage.Command.UpdateStockage
{
    public class UpdateStockageCommandValidator:AbstractValidator<UpdateStockageCommand>
    {
        IStockageRepository _stockageRepository;
        public UpdateStockageCommandValidator(IStockageRepository stockageRepository)
        {
            _stockageRepository = stockageRepository;
            RuleFor(p => p)
                .NotNull()
                .MustAsync(IsStockageUnique).WithMessage("This Stockage Name already exist");
        }

        public async Task<bool> IsStockageUnique(UpdateStockageCommand stockage, CancellationToken token)
        {
            return !await _stockageRepository.ExistsAsync(t => t.Name.ToLower() == stockage.Name.ToLower() && t.Id != stockage.Id);
        }
    }
}
