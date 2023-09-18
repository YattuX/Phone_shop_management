using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Type_.Query.GetTypeDetails
{
    public class GetTypeDetailsQueryHandler : IRequestHandler<GetTypeDetailsQuery,TypeDTO>
    {
        ITypeRepository _typeRepository;
        IMapper _mapper;
        public GetTypeDetailsQueryHandler(ITypeRepository typeRepository, IMapper mapper)
        {
           _typeRepository = typeRepository;
            _mapper = mapper;
        }

        public async Task<TypeDTO> Handle(GetTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetTypeDetailsValidator(_typeRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var type = await _typeRepository.GetByIdAsync(request.Id);
            return _mapper.Map<TypeDTO>(type);
        }
    }
}
