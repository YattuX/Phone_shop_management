using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Couleur.Command.UpdateCouleur
{
    public class UpdateCouleurCommandHandler: IRequestHandler<UpdateCouleurCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICouleurRepository _couleurRepository;
        public UpdateCouleurCommandHandler(ICouleurRepository couleur, IMapper mapper) 
        {
            _couleurRepository = couleur;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCouleurCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCouleurCommandValidator(_couleurRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var couleur = await _couleurRepository.GetByIdAsync(request.Id);

            couleur.Name = request.Name;
            couleur.CodeCouleur = request.CodeCouleur;
            
            await _couleurRepository.UpdateAsync(couleur);
            return Unit.Value;
        }
    }
}
