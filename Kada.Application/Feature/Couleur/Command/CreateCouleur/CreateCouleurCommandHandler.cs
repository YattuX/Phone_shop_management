using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Couleur.Command.CreateCouleur
{
    public class CreateCouleurCommandHandler: IRequestHandler<CreateCouleurCommand,Guid>
    {
        private ICouleurRepository _couleurRepository;
        private IMapper _mapper;
        public CreateCouleurCommandHandler(ICouleurRepository couleurRepository, IMapper mapper)
        {
            _couleurRepository = couleurRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateCouleurCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCouleurCommandValidator(_couleurRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var couleur = _mapper.Map<Domain.Couleur>(request);
            await _couleurRepository.CreateAsync(couleur);
            return couleur.Id;
        }
    }
}
