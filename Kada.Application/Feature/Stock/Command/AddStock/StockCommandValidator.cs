using FluentValidation;
using Kada.Application.Contracts.Pesistence;
using Kada.Domain;
using Kada.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Stock.Command.AddStock
{
    public class StockCommandValidator : AbstractValidator<AddStockCommand>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IStockRepository _stockRepository; 

        public StockCommandValidator(IArticleRepository articleRepository, IStockRepository stockRepository)
        {
            _articleRepository = articleRepository;
            _stockRepository = stockRepository;

            RuleFor(q => q)
                .MustAsync(HaveQuantity).WithMessage("Pas de stock disponible");
            RuleFor(q => q.Quantite)
                .NotNull()
                .NotEmpty().WithMessage("Quantity Must not be empty or 0")
                .GreaterThan(0).WithMessage("Quantity Must be greater than 0");
            RuleFor(t => t.Type)
                .NotEmpty().WithMessage("Type Must not be null")
                .NotEmpty().WithMessage("Type Must not be empty")
                .IsInEnum()
                .MustAsync(EqualToOneOrTwo);
            RuleFor(s => s.ArticleId)
                .MustAsync(DoesArticleExist)
                .WithMessage("This article does not exist");
        }

        public async Task<bool> EqualToOneOrTwo(TypeStockage type, CancellationToken cancellationToken)
        {
            return type == TypeStockage.entree || type == TypeStockage.sortie;
        } 

        public  async Task<bool> DoesArticleExist(Guid Id , CancellationToken cancellationToken)
        {
            return await _articleRepository.ExistsAsync(s => s.Id == Id);
        }

        public async Task<bool> HaveQuantity(AddStockCommand stock, CancellationToken cancellationToken)
        {
            if (stock.Type == TypeStockage.entree) return true;
            var stocks = _stockRepository.GetQuery("Article");
            var quantiteRestante = stocks
                                    .Where(s => s.ArticleId == stock.ArticleId && s.Type == TypeStockage.entree)
                                    .Sum(x => x.Quantite) - stocks
                                                            .Where(s => s.ArticleId == stock.ArticleId && s.Type == TypeStockage.sortie)
                                                            .Sum(x => x.Quantite);
            var result = quantiteRestante >= 0 && (quantiteRestante - stock.Quantite ) >= 0;
            return result;
        }
    }
}
