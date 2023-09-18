using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Type_.Command.UpdateType
{
    public class UpdateTypeCommandHandler: IRequestHandler<UpdateTypeCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly ITypeRepository _typeRepository;
        public UpdateTypeCommandHandler(ITypeRepository type, IMapper mapper) 
        {
            _typeRepository = type;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTypeCommandValidator(_typeRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var type = await _typeRepository.GetByIdAsync(request.Id);

            type.Content = request.Content;
            
            await _typeRepository.UpdateAsync(type);
            return Unit.Value;
        }
    }
}
