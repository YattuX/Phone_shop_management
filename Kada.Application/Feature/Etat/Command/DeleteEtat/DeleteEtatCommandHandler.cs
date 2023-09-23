using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Etat.Command.DeleteEtat
{
    public class DeleteEtatCommandHandler: IRequestHandler<DeleteEtatCommand, Unit>
    {
        private IEtatRepository _etatRepository;
        public DeleteEtatCommandHandler(IEtatRepository etatRepository)
        {
            _etatRepository = etatRepository;
        }

        public async Task<Unit> Handle(DeleteEtatCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteEtatCommandValidator(_etatRepository);
            var resultValidator = await validator.ValidateAsync(request, cancellationToken);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage,resultValidator);
            }
            var etat = await _etatRepository.GetByIdAsync(request.Id);
            await _etatRepository.DeleteAsync(etat);
            return Unit.Value;
        }
    }
}
