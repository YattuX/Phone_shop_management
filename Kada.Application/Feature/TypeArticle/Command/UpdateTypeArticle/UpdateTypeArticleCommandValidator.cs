using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.TypeArticle.Command.UpdateTypeArticle
{
    public class UpdateTypeArticleCommandValidator:AbstractValidator<UpdateTypeArticleCommand>
    {
        ITypeArticleRepository _typeArticleRepository;
        public UpdateTypeArticleCommandValidator(ITypeArticleRepository typeArticleRepository)
        {
            _typeArticleRepository = typeArticleRepository;
            RuleFor(p => p)
                .NotNull()
                .MustAsync(IsTypeArticleUnique).WithMessage("This Type Article Name already exist");
        }

        public async Task<bool> IsTypeArticleUnique(UpdateTypeArticleCommand typeArticle, CancellationToken token)
        {
            return !await _typeArticleRepository.ExistsAsync(t => t.Name.ToLower() == typeArticle.Name.ToLower() && t.Id != typeArticle.Id);
        }
    }
}
