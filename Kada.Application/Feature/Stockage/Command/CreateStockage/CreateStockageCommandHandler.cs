using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Stockage.Command.CreateStockage
{
    public class CreateStockageCommandHandler: IRequestHandler<CreateStockageCommand,Guid>
    {
        private IStockageRepository _stockageRepository;
        private IMapper _mapper;
        public CreateStockageCommandHandler(IStockageRepository stockageRepository, IMapper mapper)
        {
            _stockageRepository = stockageRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateStockageCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateStockageCommandValidator(_stockageRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var stockage = _mapper.Map<Domain.Stockage>(request);
            await _stockageRepository.CreateAsync(stockage);
            return stockage.Id;
        }
    }
}
