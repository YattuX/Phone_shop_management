using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Model.Command.UpdateModel
{
    public class UpdateModelCommandValidator:AbstractValidator<UpdateModelCommand>
    {
        private readonly IModelRepository _modelRepository;
        private readonly IMarqueRepository _marqueRepository;
        public UpdateModelCommandValidator(IModelRepository modelRepository, IMarqueRepository marqueRepository)
        {
            _modelRepository = modelRepository;
            _marqueRepository = marqueRepository;
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(IsExist).WithMessage("This Model does Not exist");
            RuleFor(t => t.Name)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} must not be empty");
            RuleFor(t => t.MarqueId)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} must not be empty");
            RuleFor(p => p.MarqueId)
                .MustAsync(MarqueExist)
                .WithMessage("{PropertyName} does not exist");
        }

        public async Task<bool> IsExist(Guid id, CancellationToken token)
        {
            return await _modelRepository.ExistsAsync(t => t.Id == id);
        }

        private async Task<bool> MarqueExist(Guid id, CancellationToken cancellationToken)
        {
            return await _marqueRepository.ExistsAsync(v => v.Id == id);
        }
    }
}
