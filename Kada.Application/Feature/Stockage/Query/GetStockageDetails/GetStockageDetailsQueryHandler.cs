using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Stockage.Query.GetStockageDetails
{
    public class GetStockageDetailsQueryHandler : IRequestHandler<GetStockageDetailsQuery,StockageDTO>
    {
        IStockageRepository _stockageRepository;
        IMapper _mapper;
        public GetStockageDetailsQueryHandler(IStockageRepository stockageRepository, IMapper mapper)
        {
           _stockageRepository = stockageRepository;
            _mapper = mapper;
        }

        public async Task<StockageDTO> Handle(GetStockageDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetStockageDetailsValidator(_stockageRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var stockage = await _stockageRepository.GetByIdAsync(request.Id);
            return _mapper.Map<StockageDTO>(stockage);
        }
    }
}
