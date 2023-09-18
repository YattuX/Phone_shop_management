using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Type_.Command.CreateType
{
    public class CreateTypeCommandHandler: IRequestHandler<CreateTypeCommand,Guid>
    {
        private ITypeRepository _typeRepository;
        private IMapper _mapper;
        public CreateTypeCommandHandler(ITypeRepository typeRepository, IMapper mapper)
        {
            _typeRepository = typeRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTypeCommandValidator(_typeRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var type = _mapper.Map<Domain.Type_>(request);
            await _typeRepository.CreateAsync(type);
            return type.Id;
        }
    }
}
