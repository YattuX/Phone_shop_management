using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Stockage.Command.DeleteStockage
{
    public class DeleteStockageCommandHandler: IRequestHandler<DeleteStockageCommand, Unit>
    {
        private IStockageRepository _typeArticleRepository;
        public DeleteStockageCommandHandler(IStockageRepository typeArticleRepository)
        {
            _typeArticleRepository = typeArticleRepository;
        }

        public async Task<Unit> Handle(DeleteStockageCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteStockageCommandValidator(_typeArticleRepository);
            var resultValidator = await validator.ValidateAsync(request, cancellationToken);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage,resultValidator);
            }
            var typeArticle = await _typeArticleRepository.GetByIdAsync(request.Id);
            await _typeArticleRepository.DeleteAsync(typeArticle);
            return Unit.Value;
        }
    }
}
