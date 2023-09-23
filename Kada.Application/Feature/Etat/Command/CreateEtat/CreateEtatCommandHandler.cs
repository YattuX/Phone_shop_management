using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Etat.Command.CreateEtat
{
    public class CreateEtatCommandHandler: IRequestHandler<CreateEtatCommand,Guid>
    {
        private IEtatRepository _etatRepository;
        private IMapper _mapper;
        public CreateEtatCommandHandler(IEtatRepository etatRepository, IMapper mapper)
        {
            _etatRepository = etatRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateEtatCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEtatCommandValidator(_etatRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var etat = _mapper.Map<Domain.Etat>(request);
            await _etatRepository.CreateAsync(etat);
            return etat.Id;
        }
    }
}
