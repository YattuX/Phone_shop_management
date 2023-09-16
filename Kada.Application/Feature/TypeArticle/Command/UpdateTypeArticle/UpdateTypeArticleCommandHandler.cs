using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.TypeArticle.Command.UpdateTypeArticle
{
    public class UpdateTypeArticleCommandHandler: IRequestHandler<UpdateTypeArticleCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly ITypeArticleRepository _typeArticleRepository;
        public UpdateTypeArticleCommandHandler(ITypeArticleRepository typeArticle, IMapper mapper) 
        {
            _typeArticleRepository = typeArticle;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTypeArticleCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTypeArticleCommandValidator(_typeArticleRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var typeArticle = await _typeArticleRepository.GetByIdAsync(request.Id);

            typeArticle.Name = request.Name;
            
            await _typeArticleRepository.UpdateAsync(typeArticle);
            return Unit.Value;
        }
    }
}
