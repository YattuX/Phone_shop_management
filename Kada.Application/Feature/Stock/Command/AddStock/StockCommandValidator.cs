using FluentValidation;
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
        public StockCommandValidator()
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


        }

        public async Task<bool> EqualToOneOrTwo(TypeStockage type, CancellationToken cancellationToken)
        {
            return type == TypeStockage.entree || type == TypeStockage.entree;
        } 
    }
}
