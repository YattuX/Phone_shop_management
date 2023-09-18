using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Type_.Command.DeleteType
{
    public class DeleteTypeCommandHandler: IRequestHandler<DeleteTypeCommand, Unit>
    {
        private ITypeRepository _typeRepository;
        public DeleteTypeCommandHandler(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<Unit> Handle(DeleteTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteTypeCommandValidator(_typeRepository);
            var resultValidator = await validator.ValidateAsync(request, cancellationToken);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage,resultValidator);
            }
            var type = await _typeRepository.GetByIdAsync(request.Id);
            await _typeRepository.DeleteAsync(type);
            return Unit.Value;
        }
    }
}
