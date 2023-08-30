using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Client_.Command.CreateClient
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator() 
        { 
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(2).WithMessage("{PropertyName} muster be greather than 1 character");
            RuleFor(p => p.LastName)
                .NotEmpty()
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
            RuleFor(p => p.PhoneNumber)
                .NotEmpty()
                .NotNull()
                .MaximumLength(9).WithMessage("{PropertyName} must be fewer than 9 characters");
            RuleFor(p => p.WhatsappNumber)
                .NotEmpty()
                .NotNull()
                .MaximumLength(9).WithMessage("{PropertyName} must be fewer than 9 characters");
            RuleFor(p => p.Adress)
               .NotEmpty()
               .NotNull()
               .MaximumLength(100).WithMessage("{PropertyName} must be fewer than 100 characters");
        }
    }
}
