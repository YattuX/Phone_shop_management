using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Model.Command.DeleteModel
{
    public class DeleteModelCommandHandler: IRequestHandler<DeleteModelCommand, Unit>
    {
        private IModelRepository _modelRepository;
        public DeleteModelCommandHandler(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task<Unit> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteModelCommandValidator(_modelRepository);
            var resultValidator = await validator.ValidateAsync(request, cancellationToken);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage,resultValidator);
            }
            var model = await _modelRepository.GetByIdAsync(request.Id);
            await _modelRepository.DeleteAsync(model);
            return Unit.Value;
        }
    }
}
