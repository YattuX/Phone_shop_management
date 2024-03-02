using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using Kada.Domain.Enums;
using MediatR;

namespace Kada.Application.Feature.Reparation.Command.UpdateEtatReparation
{
    public class UpdateEtatReparationCommandHandler : IRequestHandler<UpdateEtatReparationCommand, Unit>
    {
        private readonly IReparationRepository _reparationRepository;

        public UpdateEtatReparationCommandHandler(IReparationRepository reparationRepository)
        {
            this._reparationRepository = reparationRepository;
        }
        public async Task<Unit> Handle(UpdateEtatReparationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEtatReparationCommandValidator(_reparationRepository);
            var resultValidator = await validator.ValidateAsync(request, cancellationToken);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }

            var reparation = await _reparationRepository.GetByIdAsync(request.Id);

            reparation.EtatReparation = reparation.EtatReparation.NextEtape();

            await _reparationRepository.UpdateAsync(reparation);
            return Unit.Value;
        }
    }
}
