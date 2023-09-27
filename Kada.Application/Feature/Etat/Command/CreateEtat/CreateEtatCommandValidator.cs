using Kada.Application.Contracts.Pesistence;
using FluentValidation;
using AutoMapper;

namespace Kada.Application.Feature.Etat.Command.CreateEtat
{
    public class CreateEtatCommandValidator:AbstractValidator<CreateEtatCommand>
    {
        private IEtatRepository _etatRepository;
        public CreateEtatCommandValidator( IEtatRepository etatRepository)
        {
            _etatRepository = etatRepository;
            RuleFor(t => t.Content)
                .NotEmpty()
                .NotNull()
                .MaximumLength(255).WithMessage("{PropertyName} must be fewer than 255 characters");
        }
    }
}
