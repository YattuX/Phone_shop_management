using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Marque.Command.DeleteMarque
{
    public class DeleteMarqueCommandValidator:AbstractValidator<DeleteMarqueCommand>
    {
        private IMarqueRepository _marqueRepository;
        public DeleteMarqueCommandValidator(IMarqueRepository marqueRepository)
        {
            _marqueRepository = marqueRepository;
            RuleFor(p => p)
                .NotNull()
                .MustAsync(MarqueExist).WithMessage("This marque doesn't exist");
        }
        
        public async Task<bool> MarqueExist(DeleteMarqueCommand command, CancellationToken cancellationToken)
        {
            return await _marqueRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
