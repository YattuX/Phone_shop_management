using Kada.Application.Contracts.Pesistence;
using FluentValidation;
using AutoMapper;

namespace Kada.Application.Feature.Marque.Command.CreateMarque
{
    public class CreateMarqueCommandValidator:AbstractValidator<CreateMarqueCommand>
    {
        private IMarqueRepository _marqueRepository;
        private ITypeArticleRepository _typeArticleRepository;
        public CreateMarqueCommandValidator( IMarqueRepository marqueRepository, ITypeArticleRepository typeArticleRepository)
        {
            _marqueRepository = marqueRepository;
            _typeArticleRepository = typeArticleRepository;
            RuleFor(t => t.Name)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} must not be empty");
            RuleFor(t => t.TypeArticleId)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} must not be empty");
            RuleFor(p => p.TypeArticleId)
                .MustAsync(TypeArticleExist)
                .WithMessage("{PropertyName} does not exist");
        }

        private async Task<bool> TypeArticleExist(Guid id, CancellationToken cancellationToken)
        {
            return await _typeArticleRepository.ExistsAsync(v=>v.Id == id);
        }
    }
}
