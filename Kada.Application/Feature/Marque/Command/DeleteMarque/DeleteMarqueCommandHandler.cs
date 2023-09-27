using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Marque.Command.DeleteMarque
{
    public class DeleteMarqueCommandHandler: IRequestHandler<DeleteMarqueCommand, Unit>
    {
        private IMarqueRepository _marqueRepository;
        public DeleteMarqueCommandHandler(IMarqueRepository marqueRepository)
        {
            _marqueRepository = marqueRepository;
        }

        public async Task<Unit> Handle(DeleteMarqueCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteMarqueCommandValidator(_marqueRepository);
            var resultValidator = await validator.ValidateAsync(request, cancellationToken);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage,resultValidator);
            }
            var marque = await _marqueRepository.GetByIdAsync(request.Id);
            await _marqueRepository.DeleteAsync(marque);
            return Unit.Value;
        }
    }
}
