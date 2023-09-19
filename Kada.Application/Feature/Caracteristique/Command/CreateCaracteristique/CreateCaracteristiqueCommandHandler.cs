using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Caracteristique.Command.CreateCaracteristique
{
    public class CreateCaracteristiqueCommandHandler: IRequestHandler<CreateCaracteristiqueCommand,Guid>
    {
        private ICaracteristiqueRepository _CaracteristiqueRepository;
        private IModelRepository _modelRepository;
        private IMapper _mapper;
        public CreateCaracteristiqueCommandHandler(ICaracteristiqueRepository CaracteristiqueRepository, IMapper mapper, IModelRepository ModelRepository)
        {
            _CaracteristiqueRepository = CaracteristiqueRepository;
            _mapper = mapper;
            _modelRepository = ModelRepository;
        }

        public async Task<Guid> Handle(CreateCaracteristiqueCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCaracteristiqueCommandValidator(_CaracteristiqueRepository, _modelRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var Caracteristique = _mapper.Map<Domain.Caracteristique>(request);
            await _CaracteristiqueRepository.CreateAsync(Caracteristique);
            return Caracteristique.Id;
        }
    }
}
