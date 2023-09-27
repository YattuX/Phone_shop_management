using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Model.Query.GetModelDetails
{
    public class GetModelDetailsValidator : AbstractValidator<GetModelDetailsQuery>
    {
        private readonly IModelRepository _modelRepository;
        public GetModelDetailsValidator( IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;

            RuleFor(p => p)
                .NotNull()
                .NotEmpty()
                .MustAsync(ModelExist).WithMessage("This Model doesn't exist");
        }

        public async Task<bool> ModelExist(GetModelDetailsQuery command, CancellationToken token)
        {
            return await _modelRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
