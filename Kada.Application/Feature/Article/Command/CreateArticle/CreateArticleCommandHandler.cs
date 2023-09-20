using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using Kada.Application.Feature.Article.Command.CreateArticle;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Article.Command.CreateArticle
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Guid>
    {
        private IArticleRepository _articleRepository;
        private ICaracteristiqueRepository _caracteristiqueRepository;
        private IMapper _mapper;
        public CreateArticleCommandHandler(IArticleRepository ArticleRepository, IMapper mapper, ICaracteristiqueRepository CaracteristiqueRepository)
        {
            _articleRepository = ArticleRepository;
            _mapper = mapper;
            _caracteristiqueRepository = CaracteristiqueRepository;
        }

        public async Task<Guid> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateArticleCommandValidator(_articleRepository, _caracteristiqueRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var Article = _mapper.Map<Domain.Article>(request);
            await _articleRepository.CreateAsync(Article);
            return Article.Id;
        }
    }
}
