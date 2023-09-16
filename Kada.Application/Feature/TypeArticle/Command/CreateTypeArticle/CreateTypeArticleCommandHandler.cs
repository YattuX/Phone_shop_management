using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.TypeArticle.Command.CreateTypeArticle
{
    public class CreateTypeArticleCommandHandler: IRequestHandler<CreateTypeArticleCommand,Guid>
    {
        private ITypeArticleRepository _typeArticleRepository;
        private IMapper _mapper;
        public CreateTypeArticleCommandHandler(ITypeArticleRepository typeArticleRepository, IMapper mapper)
        {
            _typeArticleRepository = typeArticleRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateTypeArticleCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTypeArticleCommandValidator(_typeArticleRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var typeArticle = _mapper.Map<Domain.TypeArticle>(request);
            await _typeArticleRepository.CreateAsync(typeArticle);
            return typeArticle.Id;
        }
    }
}
