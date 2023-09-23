using Kada.Application.Contracts.Pesistence;
using FluentValidation;

namespace Kada.Application.Feature.Stockage.Command.CreateStockage
{
    public class CreateStockageCommandValidator:AbstractValidator<CreateStockageCommand>
    {
        IStockageRepository _stockageRepository;
        public CreateStockageCommandValidator( IStockageRepository stockageRepository)
        {
            _stockageRepository = stockageRepository;

            RuleFor(t => t.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters")
                .MustAsync(NameIsUnique);
        }

        public async Task<bool> NameIsUnique(string Name, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(Name))
            {
                return false;
            }
            return !await _stockageRepository.ExistsAsync(t=>  t.Name.ToLower() == Name.ToLower());
        }
    }
}
