using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Article.Command.DeleteArticle
{
    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand,Unit>
    {
        private IArticleRepository _articleRepository;
        public DeleteArticleCommandHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<Unit> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteArticleCommandValidator(_articleRepository);
            var resultValidator = await validator.ValidateAsync(request, cancellationToken);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var article = await _articleRepository.GetByIdAsync(request.Id);
            await _articleRepository.DeleteAsync(article);
            return Unit.Value;
        }
    }
}
