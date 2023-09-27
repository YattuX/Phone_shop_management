using FluentValidation;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Feature.Article.Command.CreateArticle;

namespace Kada.Application.Feature.Article.Command.UpdateArticle
{
    public class UpdateArticleCommandValidator:AbstractValidator<UpdateArticleCommand>
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICaracteristiqueRepository _caracteristiqueRepository;
        private IStockageRepository _stockageRepository;
        private ICouleurRepository _couleurRepository;
        private IParticulariteRepository _particulariteRepository;
        private IEtatRepository _etatRepository;
        private ITypeRepository _typeRepository;
        public UpdateArticleCommandValidator(IArticleRepository articleRepository, ICaracteristiqueRepository caracteristiqueRepository,
             IStockageRepository stockageRepository,
            ICouleurRepository couleurRepository,
            IParticulariteRepository particulariteRepository,
            IEtatRepository etatRepository, ITypeRepository typeRepository)
        {
            _articleRepository = articleRepository;
            _caracteristiqueRepository = caracteristiqueRepository;
            _stockageRepository = stockageRepository;
            _couleurRepository = couleurRepository;
            _particulariteRepository = particulariteRepository;
            _etatRepository = etatRepository;
            _typeRepository = typeRepository;
            RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(IsExist).WithMessage("This Article Not exist");
            RuleFor(t => t.CaracteristiqueId)
                .NotEmpty()
                .NotNull()
                .WithMessage("{PropertyName} must not be empty");
            RuleFor(p => p.CaracteristiqueId)
                .MustAsync(CaracteristiqueExist)
                .WithMessage("{PropertyName} does not exist");
            RuleFor(p => p)
                .MustAsync(IsImeiExist)
                .WithMessage("{PropertyName} must be unique and required");
            RuleFor(p => p)
                .MustAsync(StockageIsRequired)
                .WithMessage("{PropertyName} must exist and is mandatory");
            RuleFor(p => p)
                .MustAsync(CouleurIsRequired)
                .WithMessage("{PropertyName} must exist and is mandatory");
            RuleFor(p => p)
                .MustAsync(ParticulariteIsRequired)
                .WithMessage("{PropertyName} must exist and is mandatory");
            RuleFor(p => p)
                .MustAsync(EtatIsRequired)
                .WithMessage("{PropertyName} must exist and is mandatory");
            RuleFor(p => p)
                .MustAsync(TypeIsRequired)
                .WithMessage("{PropertyName} must exist and is mandatory");
            RuleFor(p => p)
                .MustAsync(NombreDeSimIsRequired)
                .WithMessage("{PropertyName} must not be empty");
            RuleFor(p => p)
                .MustAsync(ProcesseursIsRequired)
                .WithMessage("{PropertyName} must not be empty");
            RuleFor(p => p)
                .MustAsync(TailleEcranIsRequired)
                .WithMessage("{PropertyName} must not be empty");
            RuleFor(p => p)
                .MustAsync(RamIsRequired)
                .WithMessage("{PropertyName} must not be empty");
            RuleFor(p => p)
                .MustAsync(QualiteIsRequired)
                .WithMessage("{PropertyName} must not be empty");
            RuleFor(p => p)
                .MustAsync(CapaciteIsRequired)
                .WithMessage("{PropertyName} must not be empty");
            RuleFor(p => p)
                .MustAsync(PuissanceIsRequired)
                .WithMessage("{PropertyName} must not be empty");
            RuleFor(p => p)
                .MustAsync(CameraIsRequired)
                .WithMessage("{PropertyName} must not be empty");
        }

        public async Task<bool> IsExist(Guid id, CancellationToken token)
        {
            return await _articleRepository.ExistsAsync(t => t.Id == id);
        }

        private async Task<bool> CaracteristiqueExist(Guid id, CancellationToken cancellationToken)
        {
            return await _caracteristiqueRepository.ExistsAsync(v => v.Id == id);
        }

        private async Task<bool> IsImeiExist(UpdateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasImei)
            {
                article.Imei = null;
                return true;
            }
            if (string.IsNullOrWhiteSpace(article.Imei))
            {
                return false;
            }
            return !await _articleRepository.ExistsAsync(v => v.Imei == article.Imei && article.Id != v.Id);
        }

        private async Task<bool> StockageIsRequired(UpdateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasStockage)
            {
                article.StockageId = null;
                return true;
            }
            if (!article.StockageId.HasValue)
            {
                return false;
            }
            return await _stockageRepository.ExistsAsync(v => v.Id == article.StockageId);
        }

        private async Task<bool> CouleurIsRequired(UpdateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasCouleur)
            {
                article.CouleurId = null;
                return true;
            }
            if (!article.CouleurId.HasValue)
            {
                return false;
            }
            return await _couleurRepository.ExistsAsync(v => v.Id == article.CouleurId);

        }

        private async Task<bool> ParticulariteIsRequired(UpdateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasParticularite)
            {
                article.ParticulariteId = null;
                return true;
            }
            if (!article.ParticulariteId.HasValue)
            {
                return false;
            }
            return await _particulariteRepository.ExistsAsync(v => v.Id == article.ParticulariteId);

        }

        private async Task<bool> EtatIsRequired(UpdateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasEtat)
            {
                article.EtatId = null;
                return true;
            }
            if (!article.EtatId.HasValue)
            {
                return false;
            }
            return await _etatRepository.ExistsAsync(v => v.Id == article.EtatId);

        }

        private async Task<bool> TypeIsRequired(UpdateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasType)
            {
                article.TypeId = null;
                return true;
            }
            if (!article.TypeId.HasValue)
            {
                return false;
            }
            return await _typeRepository.ExistsAsync(v => v.Id == article.TypeId);

        }

        private async Task<bool> NombreDeSimIsRequired(UpdateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasNombreDeSim)
            {
                article.NombreDeSim = null;
                return true;
            }

            return article.NombreDeSim != null;

        }

        private async Task<bool> ProcesseursIsRequired(UpdateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasProcesseurs)
            {
                article.Processeurs = null;
                return true;
            }
            return article.Processeurs != null;

        }

        private async Task<bool> TailleEcranIsRequired(UpdateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasTailleEcran)
            {
                article.TailleEcran = null;
                return true;
            }
            return article.TailleEcran != null;

        }

        private async Task<bool> RamIsRequired(UpdateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasRam)
            {
                article.Ram = null;
                return true;
            }
            return article.Ram != null;

        }

        private async Task<bool> QualiteIsRequired(UpdateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasQualite)
            {
                article.Qualite = null;
                return true;
            }
            return article.Qualite != null;

        }

        private async Task<bool> CapaciteIsRequired(UpdateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasCapacite)
            {
                article.Capacite = null;
                return true;
            }
            return article.Capacite != null;

        }

        private async Task<bool> PuissanceIsRequired(UpdateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasPuissance)
            {
                article.Puissance = null;
                return true;
            }
            return article.Puissance != null;

        }

        private async Task<bool> CameraIsRequired(UpdateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasCamera)
            {
                article.Camera = null;
                return true;
            }
            return article.Camera != null;

        }

        private async Task<Domain.Caracteristique> GetCaracteristiqueAsync(Guid id)
        {
            return await _caracteristiqueRepository.GetByIdAsync(id);
        }

    }
}
