using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Particularite.Command.DeleteParticularite
{
    public class DeleteParticulariteCommandHandler: IRequestHandler<DeleteParticulariteCommand, Unit>
    {
        private IParticulariteRepository _particulariteRepository;
        public DeleteParticulariteCommandHandler(IParticulariteRepository particulariteRepository)
        {
            _particulariteRepository = particulariteRepository;
        }

        public async Task<Unit> Handle(DeleteParticulariteCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteParticulariteCommandValidator(_particulariteRepository);
            var resultValidator = await validator.ValidateAsync(request, cancellationToken);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage,resultValidator);
            }
            var particularite = await _particulariteRepository.GetByIdAsync(request.Id);
            await _particulariteRepository.DeleteAsync(particularite);
            return Unit.Value;
        }
    }
}
