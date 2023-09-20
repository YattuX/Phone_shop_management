using FluentValidation;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Feature.Article.Command.CreateArticle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Article.Command.CreateArticle
{
    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        private IArticleRepository _articleRepository;
        private ICaracteristiqueRepository _caracteristiqueRepository;
        public CreateArticleCommandValidator(IArticleRepository articleRepository, ICaracteristiqueRepository caracteristiqueRepository)
        {
            _articleRepository = articleRepository;
            _caracteristiqueRepository = caracteristiqueRepository;
            RuleFor(t => t.Nom)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} must not be empty");
            RuleFor(t => t.Imei)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} must not be empty");
            
            RuleFor(p => p.CaracteristiqueId)
                .MustAsync(CaracteristiqueExist)
                .WithMessage("{PropertyName} does not exist");

        }

        private async Task<bool> CaracteristiqueExist(Guid id, CancellationToken cancellationToken)
        {
            return await _caracteristiqueRepository.ExistsAsync(v => v.Id == id);
        }
    }
}
