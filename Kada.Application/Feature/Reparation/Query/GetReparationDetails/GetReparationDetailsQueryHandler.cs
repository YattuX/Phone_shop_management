using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Reparation.Query.GetReparationDetails
{
    public class GetReparationDetailsQueryHandler : IRequestHandler<GetReparationDetailsQuery, ReparationDTO>
    {
        IReparationRepository _reparationRepository;
        IMapper _mapper;
        public GetReparationDetailsQueryHandler(IReparationRepository reparationRepository, IMapper mapper)
        {
            _reparationRepository = reparationRepository;
            _mapper = mapper;
        }
        public async Task<ReparationDTO> Handle(GetReparationDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetReparationDetailsValidator(_reparationRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var reparation =  _reparationRepository.GetQuery("Client,Article.Caracteristique.Model").Where(x => x.Id == request.Id).FirstOrDefault();
            return _mapper.Map<ReparationDTO>(reparation);
        }
    }
}
