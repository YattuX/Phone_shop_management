using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.TypeArticle.Command.DeleteTypeArticle
{
    public class DeleteTypeArticleCommandHandler: IRequestHandler<DeleteTypeArticleCommand, Unit>
    {
        private ITypeArticleRepository _typeArticleRepository;
        public DeleteTypeArticleCommandHandler(ITypeArticleRepository typeArticleRepository)
        {
            _typeArticleRepository = typeArticleRepository;
        }

        public async Task<Unit> Handle(DeleteTypeArticleCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteTypeArticleCommandValidator(_typeArticleRepository);
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
