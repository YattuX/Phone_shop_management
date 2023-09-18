using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Type_.Command.DeleteType
{
    public class DeleteTypeCommandValidator:AbstractValidator<DeleteTypeCommand>
    {
        private ITypeRepository _typeRepository;
        public DeleteTypeCommandValidator(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
            RuleFor(p => p)
                .NotNull()
                .MustAsync(TypeExist).WithMessage("This type doesn't exist");
        }
        
        public async Task<bool> TypeExist(DeleteTypeCommand command, CancellationToken cancellationToken)
        {
            return await _typeRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
