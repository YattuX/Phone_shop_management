using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Reparation.Command.DeleteReparation
{
    public class DeleteReparationCommandHandler : IRequestHandler<DeleteReparationCommand,Unit>
    {
        private IReparationRepository _reparationRepository;
        public DeleteReparationCommandHandler(IReparationRepository reparationRepository)
        {
            _reparationRepository = reparationRepository;
        }

        public async Task<Unit> Handle(DeleteReparationCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteReparationCommandValidator(_reparationRepository);
            var resultValidator = await validator.ValidateAsync(request, cancellationToken);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var reparation = await _reparationRepository.GetByIdAsync(request.Id);
            await _reparationRepository.DeleteAsync(reparation);
            return Unit.Value;
        }
    }
}
