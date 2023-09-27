using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Model.Query.GetModelDetails
{
    public class GetModelDetailsQueryHandler : IRequestHandler<GetModelDetailsQuery,ModelDTO>
    {
        IModelRepository _modelRepository;
        IMapper _mapper;
        public GetModelDetailsQueryHandler(IModelRepository modelRepository, IMapper mapper)
        {
           _modelRepository = modelRepository;
            _mapper = mapper;
        }

        public async Task<ModelDTO> Handle(GetModelDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetModelDetailsValidator(_modelRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var model = await _modelRepository.GetByIdAsync(request.Id);
            return _mapper.Map<ModelDTO>(model);
        }
    }
}
