using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Marque.Command.UpdateMarque
{
    public class UpdateMarqueCommandValidator:AbstractValidator<UpdateMarqueCommand>
    {
        private readonly IMarqueRepository _marqueRepository;
        private readonly ITypeArticleRepository _typeArticleRepository;
        public UpdateMarqueCommandValidator(IMarqueRepository marqueRepository, ITypeArticleRepository typeArticleRepository)
        {
            _marqueRepository = marqueRepository;
            _typeArticleRepository = typeArticleRepository;
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(IsExist).WithMessage("This Marque Not exist");
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

        public async Task<bool> IsExist(Guid id, CancellationToken token)
        {
            return await _marqueRepository.ExistsAsync(t => t.Id == id);
        }

        private async Task<bool> TypeArticleExist(Guid id, CancellationToken cancellationToken)
        {
            return await _typeArticleRepository.ExistsAsync(v => v.Id == id);
        }
    }
}
