using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Marque.Query.GetMarqueDetails
{
    public class GetMarqueDetailsValidator : AbstractValidator<GetMarqueDetailsQuery>
    {
        private readonly IMarqueRepository _marqueRepository;
        public GetMarqueDetailsValidator( IMarqueRepository marqueRepository)
        {
            _marqueRepository = marqueRepository;

            RuleFor(p => p)
                .NotNull()
                .NotEmpty()
                .MustAsync(MarqueExist).WithMessage("This Marque doesn't exist");
        }

        public async Task<bool> MarqueExist(GetMarqueDetailsQuery command, CancellationToken token)
        {
            return await _marqueRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
