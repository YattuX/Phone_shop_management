using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Particularite.Command.CreateParticularite
{
    public class CreateParticulariteCommandHandler: IRequestHandler<CreateParticulariteCommand,Guid>
    {
        private IParticulariteRepository _particulariteRepository;
        private IMapper _mapper;
        public CreateParticulariteCommandHandler(IParticulariteRepository particulariteRepository, IMapper mapper)
        {
            _particulariteRepository = particulariteRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateParticulariteCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateParticulariteCommandValidator(_particulariteRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var particularite = _mapper.Map<Domain.Particularite>(request);
            await _particulariteRepository.CreateAsync(particularite);
            return particularite.Id;
        }
    }
}
