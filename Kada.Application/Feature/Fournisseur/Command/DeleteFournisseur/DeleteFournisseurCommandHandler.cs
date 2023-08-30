using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Fournisseur.Command.DeleteFournisseur
{
    public class DeleteFournisseurCommandHandler : IRequestHandler<DeleteFournisseurCommand, Unit>
    {
        IFournisseurRepository _fournisseurRepository;
        public DeleteFournisseurCommandHandler(IFournisseurRepository fournisseurRepository) 
        {
            _fournisseurRepository = fournisseurRepository;
        }

        public async Task<Unit> Handle(DeleteFournisseurCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteFournisseurCommandValidator(_fournisseurRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException("Invalid Provider Id", resultValidator);
            }
            var fournisseur = await _fournisseurRepository.GetByIdAsync(request.Id);
            await _fournisseurRepository.DeleteAsync(fournisseur);
            return Unit.Value;
        }
    }
}
