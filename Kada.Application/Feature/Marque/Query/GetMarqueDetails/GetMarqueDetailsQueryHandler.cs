using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Marque.Query.GetMarqueDetails
{
    public class GetMarqueDetailsQueryHandler : IRequestHandler<GetMarqueDetailsQuery,MarqueDTO>
    {
        IMarqueRepository _marqueRepository;
        IMapper _mapper;
        public GetMarqueDetailsQueryHandler(IMarqueRepository marqueRepository, IMapper mapper)
        {
           _marqueRepository = marqueRepository;
            _mapper = mapper;
        }

        public async Task<MarqueDTO> Handle(GetMarqueDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetMarqueDetailsValidator(_marqueRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var marque = await _marqueRepository.GetByIdAsync(request.Id);
            return _mapper.Map<MarqueDTO>(marque);
        }
    }
}
