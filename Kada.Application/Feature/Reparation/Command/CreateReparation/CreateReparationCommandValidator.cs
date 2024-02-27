using FluentValidation;
using Kada.Application.Contracts.Pesistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Reparation.Command.CreateReparation
{
    public class CreateReparationCommandValidator : AbstractValidator<CreateReparationCommand>
    {
        public CreateReparationCommandValidator(IReparationRepository reparationRepository)
        {
            RuleFor(r => r.ArticleId)
            .NotEmpty()
            .NotNull()
            .WithMessage("{PropertyName} is required");

            RuleFor(r => r.ClientId)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} is required");

            RuleFor(r => r.DescriptionProbleme)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} is required");

            RuleFor(r => r.DateDepot)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} is required");

            RuleFor(r => r.DateLivraison)
                .GreaterThanOrEqualTo(r => r.DateDepot)
                .When(r => r.DateLivraison.HasValue)
                .WithMessage("{PropertyName} must be greater than or equal to DateDepot");

            RuleFor(r => r.CoutReparation)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(0)
                .WithMessage("{PropertyName} must be greater than or equal to zero");
        }
    }
}
