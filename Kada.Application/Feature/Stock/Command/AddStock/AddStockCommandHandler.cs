using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using Kada.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Stock.Command.AddStock
{
    public class AddStockCommandHandler : IRequestHandler<AddStockCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IStockRepository _stockRepository;
        public AddStockCommandHandler(IMapper mapper, IStockRepository stockRepository)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
        }

        public async Task<Guid> Handle(AddStockCommand request, CancellationToken cancellationToken)
        {
            var validator = new StockCommandValidator();
            var resultValidator = await validator.ValidateAsync(request, cancellationToken);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }

            var stock = _mapper.Map<Domain.Stock>(request);
            await _stockRepository.CreateAsync(stock);
            return stock.Id;
        }
    }
}
