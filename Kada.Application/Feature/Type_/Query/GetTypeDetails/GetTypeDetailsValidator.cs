using FluentValidation;
using Kada.Application.Contracts.Pesistence;

namespace Kada.Application.Feature.Type_.Query.GetTypeDetails
{
    public class GetTypeDetailsValidator : AbstractValidator<GetTypeDetailsQuery>
    {
        private readonly ITypeRepository _typeRepository;
        public GetTypeDetailsValidator( ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;

            RuleFor(p => p)
                .NotNull()
                .MustAsync(TypeExist).WithMessage("This Type doesn't exist");
        }

        public async Task<bool> TypeExist(GetTypeDetailsQuery command, CancellationToken token)
        {
            return await _typeRepository.ExistsAsync(x => x.Id == command.Id);
        }
    }
}
