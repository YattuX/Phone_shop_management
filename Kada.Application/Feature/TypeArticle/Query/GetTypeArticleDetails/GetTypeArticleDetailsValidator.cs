using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.TypeArticle.Query.GetTypeArticleDetails
{
    public class GetTypeArticleDetailsValidator : AbstractValidator<GetTypeArticleDetailsQuery>
    {
        private readonly ITypeArticleRepository _typeArticleRepository;
        public GetTypeArticleDetailsValidator( ITypeArticleRepository typeArticleRepository)
        {
            _typeArticleRepository = typeArticleRepository;

            RuleFor(p => p)
                .NotNull()
                .MustAsync(TypeArticleExist).WithMessage("This TypeArticle doesn't exist");
        }

        public async Task<bool> TypeArticleExist(GetTypeArticleDetailsQuery command, CancellationToken token)
        {
            return await _typeArticleRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
