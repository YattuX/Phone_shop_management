using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.TypeArticle.Command.DeleteTypeArticle
{
    public class DeleteTypeArticleCommandValidator:AbstractValidator<DeleteTypeArticleCommand>
    {
        private ITypeArticleRepository _typeArticleRepository;
        public DeleteTypeArticleCommandValidator(ITypeArticleRepository typeArticleRepository)
        {
            _typeArticleRepository = typeArticleRepository;
            RuleFor(p => p)
                .NotNull()
                .MustAsync(TypeArticleExist).WithMessage("This article type doesn't exist");
        }
        
        public async Task<bool> TypeArticleExist(DeleteTypeArticleCommand command, CancellationToken cancellationToken)
        {
            return await _typeArticleRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
