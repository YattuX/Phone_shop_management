using Kada.Application.Contracts.Pesistence;
using FluentValidation;
using AutoMapper;

namespace Kada.Application.Feature.Type_.Command.CreateType
{
    public class CreateTypeCommandValidator:AbstractValidator<CreateTypeCommand>
    {
        private ITypeRepository _typeRepository;
        public CreateTypeCommandValidator( ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
            RuleFor(t => t.Content)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 100 characters");
        }
    }
}
