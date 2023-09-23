using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Article.Query.GetArticleDetails
{
    public class GetArticleDetailsQueryHandler : IRequestHandler<GetArticleDetailsQuery,ArticleDTO>
    {
        IArticleRepository _articleRepository;
        IMapper _mapper;
        public GetArticleDetailsQueryHandler(IArticleRepository articleRepository, IMapper mapper)
        {
           _articleRepository = articleRepository;
            _mapper = mapper;
        }

        public async Task<ArticleDTO> Handle(GetArticleDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetArticleDetailsValidator(_articleRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var article = await _articleRepository.GetByIdAsync(request.Id);
            return _mapper.Map<ArticleDTO>(article);
        }
    }
}
