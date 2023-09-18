using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Type_.Command.UpdateType
{
    public class UpdateTypeCommandValidator:AbstractValidator<UpdateTypeCommand>
    {
        private readonly ITypeRepository _typeRepository;
        public UpdateTypeCommandValidator(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(IsExist).WithMessage("This Type Not exist");
        }

        public async Task<bool> IsExist(Guid id, CancellationToken token)
        {
            return await _typeRepository.ExistsAsync(t => t.Id == id);
        }
    }
}
