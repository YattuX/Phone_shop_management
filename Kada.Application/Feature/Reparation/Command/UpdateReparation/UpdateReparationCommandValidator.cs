using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Reparation.Command.UpdateReparation
{
    public class UpdateReparationCommandValidator : AbstractValidator<UpdateReparationCommand>
    {
        private readonly IReparationRepository _reparationRepository;

        public UpdateReparationCommandValidator(IReparationRepository reparationRepository)
        {
            _reparationRepository = reparationRepository;

            RuleFor(r => r.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} is required")
                .MustAsync(async (Guid id, CancellationToken cancellation) =>
                {
                    return await _reparationRepository.ExistsAsync(x => x.Id == id);
                }).WithMessage("{PropertyName} does not exist");

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
