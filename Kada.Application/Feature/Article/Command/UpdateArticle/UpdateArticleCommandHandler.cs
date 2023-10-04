using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using Kada.Domain;
using MediatR;

namespace Kada.Application.Feature.Article.Command.UpdateArticle
{
    public class UpdateArticleCommandHandler: IRequestHandler<UpdateArticleCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;
        private readonly ICaracteristiqueRepository _caracteristiqueRepository;
        private IStockageRepository _stockageRepository;
        private ICouleurRepository _couleurRepository;
        private IParticulariteRepository _particulariteRepository;
        private IEtatRepository _etatRepository;
        private ITypeRepository _typeRepository;
        public UpdateArticleCommandHandler(IArticleRepository article, IMapper mapper, ICaracteristiqueRepository caracteristiqueRepository,
            IStockageRepository stockageRepository,
            ICouleurRepository couleurRepository,
            IParticulariteRepository particulariteRepository,
            IEtatRepository etatRepository, ITypeRepository typeRepository) 
        {
            _articleRepository = article;
            _mapper = mapper;
            _caracteristiqueRepository = caracteristiqueRepository;
            _stockageRepository = stockageRepository;
            _couleurRepository = couleurRepository;
            _particulariteRepository = particulariteRepository;
            _etatRepository = etatRepository;
            _typeRepository = typeRepository;
        }

        public async Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateArticleCommandValidator(_articleRepository,_caracteristiqueRepository, _stockageRepository, _couleurRepository, _particulariteRepository, _etatRepository, _typeRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var article = await _articleRepository.GetByIdAsync(request.Id);

            article.StockageId = request.StockageId;
            article.CouleurId = request.CouleurId;
            article.NombreDeSim = request.NombreDeSim;
            article.Imei = request.Imei;
            article.ParticulariteId = request.ParticulariteId;
            article.EtatId = request.EtatId;
            article.Processeurs = request.Processeurs;
            article.TailleEcran = request.TailleEcran;
            article.Ram = request.Ram;
            article.Qualite = request.Qualite;
            article.Position = request.Position;
            article.TypeId = request.TypeId;
            article.Capacite = request.Capacite;
            article.CaracteristiqueId = request.CaracteristiqueId;
            article.Puissance = request.Puissance;
            article.Description = request.Description;
            
            await _articleRepository.UpdateAsync(article);
            return Unit.Value;
        }
    }
}
