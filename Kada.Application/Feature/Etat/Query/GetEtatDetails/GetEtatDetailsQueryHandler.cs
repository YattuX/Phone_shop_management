using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Etat.Query.GetEtatDetails
{
    public class GetEtatDetailsQueryHandler : IRequestHandler<GetEtatDetailsQuery,EtatDTO>
    {
        IEtatRepository _etatRepository;
        IMapper _mapper;
        public GetEtatDetailsQueryHandler(IEtatRepository etatRepository, IMapper mapper)
        {
           _etatRepository = etatRepository;
            _mapper = mapper;
        }

        public async Task<EtatDTO> Handle(GetEtatDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetEtatDetailsValidator(_etatRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var etat = await _etatRepository.GetByIdAsync(request.Id);
            return _mapper.Map<EtatDTO>(etat);
        }
    }
}
