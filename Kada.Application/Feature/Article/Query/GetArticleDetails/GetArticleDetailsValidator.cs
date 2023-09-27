using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Article.Query.GetArticleDetails
{
    public class GetArticleDetailsValidator : AbstractValidator<GetArticleDetailsQuery>
    {
        private readonly IArticleRepository _articleRepository;
        public GetArticleDetailsValidator( IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;

            RuleFor(p => p)
                .NotNull()
                .NotEmpty()
                .MustAsync(ArticleExist).WithMessage("This Article doesn't exist");
        }

        public async Task<bool> ArticleExist(GetArticleDetailsQuery command, CancellationToken token)
        {
            return await _articleRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
