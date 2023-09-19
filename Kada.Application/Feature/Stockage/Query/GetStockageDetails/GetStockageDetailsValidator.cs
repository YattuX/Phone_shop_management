using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Stockage.Query.GetStockageDetails
{
    public class GetStockageDetailsValidator : AbstractValidator<GetStockageDetailsQuery>
    {
        private readonly IStockageRepository _stockageRepository;
        public GetStockageDetailsValidator( IStockageRepository stockageRepository)
        {
            _stockageRepository = stockageRepository;

            RuleFor(p => p)
                .NotNull()
                .MustAsync(StockageExist).WithMessage("This Stockage doesn't exist");
        }

        public async Task<bool> StockageExist(GetStockageDetailsQuery command, CancellationToken token)
        {
            return await _stockageRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
