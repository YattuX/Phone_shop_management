using Kada.Application.Contracts.Pesistence;
using FluentValidation;

namespace Kada.Application.Feature.TypeArticle.Command.CreateTypeArticle
{
    public class CreateTypeArticleCommandValidator:AbstractValidator<CreateTypeArticleCommand>
    {
        ITypeArticleRepository _typeArticleRepository;
        public CreateTypeArticleCommandValidator( ITypeArticleRepository typeArticleRepository)
        {
            _typeArticleRepository = typeArticleRepository;

            RuleFor(t => t.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters")
                .MustAsync(NameIsUnique);
        }

        public async Task<bool> NameIsUnique(string Name, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(Name))
            {
                return false;
            }
            return !await _typeArticleRepository.ExistsAsync(t=>  t.Name.ToLower() == Name.ToLower());
        }
    }
}
