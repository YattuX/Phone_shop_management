using FluentValidation;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Feature.Stock.Command.AddStock;
using Kada.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Stock.Command.UpdateStock
{
    public class UpdateStockCommandValidators : AbstractValidator<UpdateStockCommand>
    {
        private readonly IArticleRepository _articleRepository;

        public UpdateStockCommandValidators(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public UpdateStockCommandValidators()
        {
            RuleFor(q => q.Quantite)
                .NotNull()
                .NotEmpty().WithMessage("{Property Name} Must not be empty")
                .GreaterThan(0).WithMessage("{Property name} Must be greater ther 0");
            RuleFor(t => t.Type)
                .NotEmpty().WithMessage("{Property Name} Must not be null")
                .NotEmpty().WithMessage("{Property Name} Must not be empty")
                .IsInEnum()
                .MustAsync(EqualToOneOrTwo);
            RuleFor(s => s.ArticleId)
                .MustAsync(DoesArticleExist)
                .WithMessage("{Propery Name} This article does not exist");


        }

        public async Task<bool> EqualToOneOrTwo(TypeStockage type, CancellationToken cancellationToken)
        {
            return type == TypeStockage.entree || type == TypeStockage.entree;
        }

        public async Task<bool> DoesArticleExist(Guid Id, CancellationToken cancellationToken)
        {
            return await _articleRepository.ExistsAsync(s => s.Id == Id);
        }
    }
}
