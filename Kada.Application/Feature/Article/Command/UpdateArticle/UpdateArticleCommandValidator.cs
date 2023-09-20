using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Article.Command.UpdateArticle
{
    public class UpdateArticleCommandValidator:AbstractValidator<UpdateArticleCommand>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICaracteristiqueRepository _caracteristiqueRepository;
        public UpdateArticleCommandValidator(IArticleRepository articleRepository, ICaracteristiqueRepository caracteristiqueRepository)
        {
            _articleRepository = articleRepository;
            _caracteristiqueRepository = caracteristiqueRepository;
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(IsExist).WithMessage("This Article Not exist");
            RuleFor(t => t.CaracteristiqueId)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} must not be empty");
            RuleFor(p => p.CaracteristiqueId)
                .MustAsync(CaracteristiqueExist)
                .WithMessage("{PropertyName} does not exist");
        }

        public async Task<bool> IsExist(Guid id, CancellationToken token)
        {
            return await _articleRepository.ExistsAsync(t => t.Id == id);
        }

        private async Task<bool> CaracteristiqueExist(Guid id, CancellationToken cancellationToken)
        {
            return await _caracteristiqueRepository.ExistsAsync(v => v.Id == id);
        }
    }
}
