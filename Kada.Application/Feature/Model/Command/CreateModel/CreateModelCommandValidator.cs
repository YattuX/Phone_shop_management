using Kada.Application.Contracts.Pesistence;
using FluentValidation;
using AutoMapper;

namespace Kada.Application.Feature.Model.Command.CreateModel
{
    public class CreateModelCommandValidator:AbstractValidator<CreateModelCommand>
    {
        private IModelRepository _modelRepository;
        private IMarqueRepository _marqueRepository;
        public CreateModelCommandValidator( IModelRepository modelRepository, IMarqueRepository marqueRepository)
        {
            _modelRepository = modelRepository;
            _marqueRepository = marqueRepository;
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

        private async Task<bool> MarqueExist(Guid id, CancellationToken cancellationToken)
        {
            return await _marqueRepository.ExistsAsync(v=>v.Id == id);
        }
    }
}
