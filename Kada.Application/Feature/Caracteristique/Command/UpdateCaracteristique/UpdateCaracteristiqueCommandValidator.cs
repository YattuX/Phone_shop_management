using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Caracteristique.Command.UpdateCaracteristique
{
    public class UpdateCaracteristiqueCommandValidator:AbstractValidator<UpdateCaracteristiqueCommand>
    {
        private readonly ICaracteristiqueRepository _caracteristiqueRepository;
        private readonly IModelRepository _modelRepository;
        public UpdateCaracteristiqueCommandValidator(ICaracteristiqueRepository caracteristiqueRepository, IModelRepository modelRepository)
        {
            _caracteristiqueRepository = caracteristiqueRepository;
            _modelRepository = modelRepository;
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(IsExist).WithMessage("This Caracteristique Not exist");
            RuleFor(t => t.ModelId)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} must not be empty");
            RuleFor(p => p.ModelId)
                .MustAsync(ModelExist)
                .WithMessage("{PropertyName} does not exist");
        }

        public async Task<bool> IsExist(Guid id, CancellationToken token)
        {
            return await _caracteristiqueRepository.ExistsAsync(t => t.Id == id);
        }

        private async Task<bool> ModelExist(Guid id, CancellationToken cancellationToken)
        {
            return await _modelRepository.ExistsAsync(v => v.Id == id);
        }
    }
}
