using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.TypeArticle.Query.GetTypeArticleDetails
{
    public class GetTypeArticleDetailsQueryHandler : IRequestHandler<GetTypeArticleDetailsQuery,TypeArticleDTO>
    {
        ITypeArticleRepository _typeArticleRepository;
        IMapper _mapper;
        public GetTypeArticleDetailsQueryHandler(ITypeArticleRepository typeArticleRepository, IMapper mapper)
        {
           _typeArticleRepository = typeArticleRepository;
            _mapper = mapper;
        }

        public async Task<TypeArticleDTO> Handle(GetTypeArticleDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetTypeArticleDetailsValidator(_typeArticleRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var typeArticle = await _typeArticleRepository.GetByIdAsync(request.Id);
            return _mapper.Map<TypeArticleDTO>(typeArticle);
        }
    }
}
