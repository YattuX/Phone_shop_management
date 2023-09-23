using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Couleur.Query.GetCouleurDetails
{
    public class GetCouleurDetailsQueryHandler : IRequestHandler<GetCouleurDetailsQuery,CouleurDTO>
    {
        ICouleurRepository _couleurRepository;
        IMapper _mapper;
        public GetCouleurDetailsQueryHandler(ICouleurRepository couleurRepository, IMapper mapper)
        {
           _couleurRepository = couleurRepository;
            _mapper = mapper;
        }

        public async Task<CouleurDTO> Handle(GetCouleurDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCouleurDetailsValidator(_couleurRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var couleur = await _couleurRepository.GetByIdAsync(request.Id);
            return _mapper.Map<CouleurDTO>(couleur);
        }
    }
}
