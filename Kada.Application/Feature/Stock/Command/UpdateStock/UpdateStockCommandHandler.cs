using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using Kada.Application.Feature.Stock.Command.AddStock;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Stock.Command.UpdateStock
{
    public class UpdateStockCommandHandler : IRequestHandler<UpdateStockCommand, Guid>
    {

        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;
        private readonly IArticleRepository _articleRepository;
        public UpdateStockCommandHandler(
            IMapper mapper,
            IStockRepository stockRepository,
            IArticleRepository articleRepository)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
            _articleRepository = articleRepository;
        }

        public async Task<Guid> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateStockCommandValidators(_articleRepository);
            var resultValidator = await validator.ValidateAsync(request, cancellationToken);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }

            var stock = await _stockRepository.GetByIdAsync(request.Id);

            stock.ArticleId = request.ArticleId;
            stock.Quantite = request.Quantite;
            stock.Type = request.Type;
            await _stockRepository.UpdateAsync(stock);
            return stock.Id;
        }
    }
}
