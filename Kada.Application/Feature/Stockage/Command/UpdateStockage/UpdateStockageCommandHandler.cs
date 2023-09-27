using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Stockage.Command.UpdateStockage
{
    public class UpdateStockageCommandHandler: IRequestHandler<UpdateStockageCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly IStockageRepository _stockageRepository;
        public UpdateStockageCommandHandler(IStockageRepository stockage, IMapper mapper) 
        {
            _stockageRepository = stockage;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateStockageCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateStockageCommandValidator(_stockageRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var stockage = await _stockageRepository.GetByIdAsync(request.Id);

            stockage.Name = request.Name;
            
            await _stockageRepository.UpdateAsync(stockage);
            return Unit.Value;
        }
    }
}
