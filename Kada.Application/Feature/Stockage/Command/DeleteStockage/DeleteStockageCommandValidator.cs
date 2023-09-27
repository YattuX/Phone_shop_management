using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Stockage.Command.DeleteStockage
{
    public class DeleteStockageCommandValidator:AbstractValidator<DeleteStockageCommand>
    {
        private IStockageRepository _stockageRepository;
        public DeleteStockageCommandValidator(IStockageRepository stockageRepository)
        {
            _stockageRepository = stockageRepository;
            RuleFor(p => p)
                .NotNull()
                .MustAsync(StockageExist).WithMessage("This article type doesn't exist");
        }
        
        public async Task<bool> StockageExist(DeleteStockageCommand command, CancellationToken cancellationToken)
        {
            return await _stockageRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
