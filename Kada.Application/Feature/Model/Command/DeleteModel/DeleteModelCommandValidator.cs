using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Model.Command.DeleteModel
{
    public class DeleteModelCommandValidator:AbstractValidator<DeleteModelCommand>
    {
        private IModelRepository _modelRepository;
        public DeleteModelCommandValidator(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
            RuleFor(p => p)
                .NotNull().WithMessage("This model doesn't exist")
                .MustAsync(ModelExist).WithMessage("This model doesn't exist");
        }
        
        public async Task<bool> ModelExist(DeleteModelCommand command, CancellationToken cancellationToken)
        {
            return await _modelRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
