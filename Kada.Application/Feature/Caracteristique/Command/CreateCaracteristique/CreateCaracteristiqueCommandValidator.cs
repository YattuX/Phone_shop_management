using Kada.Application.Contracts.Pesistence;
using FluentValidation;
using AutoMapper;

namespace Kada.Application.Feature.Caracteristique.Command.CreateCaracteristique
{
    public class CreateCaracteristiqueCommandValidator:AbstractValidator<CreateCaracteristiqueCommand>
    {
        private ICaracteristiqueRepository _caracteristiqueRepository;
        private IModelRepository _modelRepository;
        public CreateCaracteristiqueCommandValidator( ICaracteristiqueRepository caracteristiqueRepository, IModelRepository modelRepository)
        {
            _caracteristiqueRepository = caracteristiqueRepository;
            _modelRepository = modelRepository;
            RuleFor(t => t.ModelId)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} must not be empty");
            RuleFor(p => p.ModelId)
                .MustAsync(ModelExist)
                .WithMessage("{PropertyName} does not exist");
        }

        private async Task<bool> ModelExist(Guid id, CancellationToken cancellationToken)
        {
            return await _modelRepository.ExistsAsync(v=>v.Id == id);
        }
    }
}
