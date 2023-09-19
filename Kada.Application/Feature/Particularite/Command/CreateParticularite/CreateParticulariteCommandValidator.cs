using Kada.Application.Contracts.Pesistence;
using FluentValidation;
using AutoMapper;

namespace Kada.Application.Feature.Particularite.Command.CreateParticularite
{
    public class CreateParticulariteCommandValidator:AbstractValidator<CreateParticulariteCommand>
    {
        private IParticulariteRepository _particulariteRepository;
        public CreateParticulariteCommandValidator( IParticulariteRepository particulariteRepository)
        {
            _particulariteRepository = particulariteRepository;
            RuleFor(t => t.Content)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} a must not be empty");
        }
    }
}
