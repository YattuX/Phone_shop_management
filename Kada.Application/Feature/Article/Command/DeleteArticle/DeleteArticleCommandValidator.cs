using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Article.Command.DeleteArticle
{
    public class DeleteArticleCommandValidator : AbstractValidator<DeleteArticleCommand>
    {
        private readonly IArticleRepository _articleRepository;
        public DeleteArticleCommandValidator(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
            RuleFor(a => a)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} does not be empty")
                .MustAsync(ArticleExist)
                .WithMessage("this Article doesn't exist");
        }
        public async Task<bool> ArticleExist(DeleteArticleCommand command, CancellationToken cancellationToken)
        {
            return await _articleRepository.ExistsAsync(a => a.Id == command.Id);
        }
    }
}
