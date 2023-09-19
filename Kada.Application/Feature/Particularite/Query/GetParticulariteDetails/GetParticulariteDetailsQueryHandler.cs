using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Particularite.Query.GetParticulariteDetails
{
    public class GetParticulariteDetailsQueryHandler : IRequestHandler<GetParticulariteDetailsQuery,ParticulariteDTO>
    {
        IParticulariteRepository _particulariteRepository;
        IMapper _mapper;
        public GetParticulariteDetailsQueryHandler(IParticulariteRepository particulariteRepository, IMapper mapper)
        {
           _particulariteRepository = particulariteRepository;
            _mapper = mapper;
        }

        public async Task<ParticulariteDTO> Handle(GetParticulariteDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetParticulariteDetailsValidator(_particulariteRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var particularite = await _particulariteRepository.GetByIdAsync(request.Id);
            return _mapper.Map<ParticulariteDTO>(particularite);
        }
    }
}
