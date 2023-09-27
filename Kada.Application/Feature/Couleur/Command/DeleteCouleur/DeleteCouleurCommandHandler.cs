using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Couleur.Command.DeleteCouleur
{
    public class DeleteCouleurCommandHandler: IRequestHandler<DeleteCouleurCommand, Unit>
    {
        private ICouleurRepository _couleurRepository;
        public DeleteCouleurCommandHandler(ICouleurRepository couleurRepository)
        {
            _couleurRepository = couleurRepository;
        }

        public async Task<Unit> Handle(DeleteCouleurCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteCouleurCommandValidator(_couleurRepository);
            var resultValidator = await validator.ValidateAsync(request, cancellationToken);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage,resultValidator);
            }
            var couleur = await _couleurRepository.GetByIdAsync(request.Id);
            await _couleurRepository.DeleteAsync(couleur);
            return Unit.Value;
        }
    }
}
