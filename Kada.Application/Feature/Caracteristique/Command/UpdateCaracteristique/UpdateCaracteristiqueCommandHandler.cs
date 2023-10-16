using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Caracteristique.Command.UpdateCaracteristique
{
    public class UpdateCaracteristiqueCommandHandler: IRequestHandler<UpdateCaracteristiqueCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICaracteristiqueRepository _caracteristiqueRepository;
        private readonly IModelRepository _modelRepository;
        public UpdateCaracteristiqueCommandHandler(ICaracteristiqueRepository caracteristique, IMapper mapper, IModelRepository modelRepository) 
        {
            _caracteristiqueRepository = caracteristique;
            _mapper = mapper;
            _modelRepository = modelRepository;
        }

        public async Task<Unit> Handle(UpdateCaracteristiqueCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCaracteristiqueCommandValidator(_caracteristiqueRepository,_modelRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var caracteristique = await _caracteristiqueRepository.GetByIdAsync(request.Id);

            caracteristique.HasQualite = request.HasQualite;
            caracteristique.HasCouleur = request.HasCouleur;
            caracteristique.HasProcesseurs = request.HasProcesseurs;
            caracteristique.HasPuissance = request.HasPuissance;
            caracteristique.HasParticularite = request.HasParticularite;
            caracteristique.HasCapacite = request.HasCapacite;
            caracteristique.HasPosition = request.HasPosition;
            caracteristique.HasEtat = request.HasEtat;
            caracteristique.HasImei = request.HasImei;
            caracteristique.HasNombreDeSim = request.HasNombreDeSim;
            caracteristique.HasTailleEcran = request.HasTailleEcran;
            caracteristique.HasStockage = request.HasStockage;
            caracteristique.HasType = request.HasType;
            caracteristique.ModelId = request.ModelId;
            caracteristique.HasDescription = request.HasDescription;
            
            await _caracteristiqueRepository.UpdateAsync(caracteristique);
            return Unit.Value;
        }
    }
}
