using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Caracteristique.Query.GetCaracteristiqueDetails
{
    public class GetCaracteristiqueDetailsQueryHandler : IRequestHandler<GetCaracteristiqueDetailsQuery,CaracteristiqueDTO>
    {
        ICaracteristiqueRepository _caracteristiqueRepository;
        IMapper _mapper;
        public GetCaracteristiqueDetailsQueryHandler(ICaracteristiqueRepository caracteristiqueRepository, IMapper mapper)
        {
           _caracteristiqueRepository = caracteristiqueRepository;
            _mapper = mapper;
        }

        public async Task<CaracteristiqueDTO> Handle(GetCaracteristiqueDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCaracteristiqueDetailsValidator(_caracteristiqueRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var caracteristique = await _caracteristiqueRepository.GetByIdAsync(request.Id);
            return _mapper.Map<CaracteristiqueDTO>(caracteristique);
        }
    }
}
