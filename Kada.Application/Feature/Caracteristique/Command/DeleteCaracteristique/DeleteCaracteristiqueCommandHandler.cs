using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Caracteristique.Command.DeleteCaracteristique
{
    public class DeleteCaracteristiqueCommandHandler: IRequestHandler<DeleteCaracteristiqueCommand, Unit>
    {
        private ICaracteristiqueRepository _caracteristiqueRepository;
        public DeleteCaracteristiqueCommandHandler(ICaracteristiqueRepository caracteristiqueRepository)
        {
            _caracteristiqueRepository = caracteristiqueRepository;
        }

        public async Task<Unit> Handle(DeleteCaracteristiqueCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteCaracteristiqueCommandValidator(_caracteristiqueRepository);
            var resultValidator = await validator.ValidateAsync(request, cancellationToken);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage,resultValidator);
            }
            var caracteristique = await _caracteristiqueRepository.GetByIdAsync(request.Id);
            await _caracteristiqueRepository.DeleteAsync(caracteristique);
            return Unit.Value;
        }
    }
}
