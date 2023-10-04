using FluentValidation;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Feature.Article.Command.CreateArticle;
using Kada.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Article.Command.CreateArticle
{
    public class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
    {
        private IArticleRepository _articleRepository;
        private ICaracteristiqueRepository _caracteristiqueRepository;
        private IStockageRepository _stockageRepository;
        private ICouleurRepository _couleurRepository;
        private IParticulariteRepository _particulariteRepository;
        private IEtatRepository _etatRepository;
        private ITypeRepository _typeRepository;
        public CreateArticleCommandValidator(IArticleRepository articleRepository, 
            ICaracteristiqueRepository caracteristiqueRepository, 
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

            RuleFor(p => p.CaracteristiqueId)
                .MustAsync(CaracteristiqueExist)
                .WithMessage("{PropertyName} does not exist");
            RuleFor(p => p)
                .MustAsync(IsImeiExist)
                .WithMessage("Imei must be unique and required");
            RuleFor(p => p)
                .MustAsync(StockageIsRequired)
                .WithMessage("Stockage must exist and is mandatory");
            RuleFor(p => p)
                .MustAsync(CouleurIsRequired)
                .WithMessage("Couleur must exist and is mandatory");
            RuleFor(p => p)
                .MustAsync(ParticulariteIsRequired)
                .WithMessage("Particularite must exist and is mandatory");
            RuleFor(p => p)
                .MustAsync(EtatIsRequired)
                .WithMessage("Etat must exist and is mandatory");
            RuleFor(p => p)
                .MustAsync(TypeIsRequired)
                .WithMessage("Type must exist and is mandatory");
            RuleFor(p => p)
                .MustAsync(NombreDeSimIsRequired)
                .WithMessage("Nombre de Sim must not be empty");
            RuleFor(p => p)
                .MustAsync(ProcesseursIsRequired)
                .WithMessage("Processeurs must not be empty");
            RuleFor(p => p)
                .MustAsync(TailleEcranIsRequired)
                .WithMessage("Taille Ecran must not be empty");
            RuleFor(p => p)
                .MustAsync(RamIsRequired)
                .WithMessage("Ram must not be empty");
            RuleFor(p => p)
                .MustAsync(QualiteIsRequired)
                .WithMessage("Quality must not be empty");
            RuleFor(p => p)
                .MustAsync(CapaciteIsRequired)
                .WithMessage("Capacite must not be empty");
            RuleFor(p => p)
                .MustAsync(PuissanceIsRequired)
                .WithMessage("Puissance must not be empty");
            RuleFor(p => p)
                .MustAsync(PositionIsRequired)
                .WithMessage("Puissance must not be empty");
        }

        private async Task<bool> CaracteristiqueExist(Guid id, CancellationToken cancellationToken)
        {
            return await _caracteristiqueRepository.ExistsAsync(v => v.Id == id);
        }

        private async Task<bool> IsImeiExist(CreateArticleCommand article, CancellationToken cancellationToken)
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
            return !await _articleRepository.ExistsAsync(v => v.Imei == article.Imei);
        }

        private async Task<bool> StockageIsRequired(CreateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if(!caracteristique.HasStockage) 
            {
                article.StockageId = null;
                return true;
            }
            if(!article.StockageId.HasValue) 
            {
                return false;
            }
            return await _stockageRepository.ExistsAsync(v => v.Id ==  article.StockageId);
        }

        private async Task<bool> CouleurIsRequired(CreateArticleCommand article, CancellationToken cancellationToken)
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
        
        private async Task<bool> ParticulariteIsRequired(CreateArticleCommand article, CancellationToken cancellationToken)
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
        
        private async Task<bool> EtatIsRequired(CreateArticleCommand article, CancellationToken cancellationToken)
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
        
        private async Task<bool> TypeIsRequired(CreateArticleCommand article, CancellationToken cancellationToken)
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
        
        private async Task<bool> NombreDeSimIsRequired(CreateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasNombreDeSim)
            {
                article.NombreDeSim = null;
                return true;
            }

            return article.NombreDeSim != null;

        }
        
        private async Task<bool> ProcesseursIsRequired(CreateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasProcesseurs)
            {
                article.Processeurs = null;
                return true;
            }
            return article.Processeurs != null;

        }
        
        private async Task<bool> TailleEcranIsRequired(CreateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasTailleEcran)
            {
                article.TailleEcran = null;
                return true;
            }
            return article.TailleEcran != null;

        }
        
        private async Task<bool> RamIsRequired(CreateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasRam)
            {
                article.Ram = null;
                return true;
            }
            return article.Ram != null;

        }
        
        private async Task<bool> QualiteIsRequired(CreateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasQualite)
            {
                article.Qualite = null;
                return true;
            }
            return article.Qualite != null;

        }
        
        private async Task<bool> CapaciteIsRequired(CreateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasCapacite)
            {
                article.Capacite = null;
                return true;
            }
            return article.Capacite != null;

        }
         
        private async Task<bool> PuissanceIsRequired(CreateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasPuissance)
            {
                article.Puissance = null;
                return true;
            }
            return article.Puissance != null;

        }
         
        private async Task<bool> PositionIsRequired(CreateArticleCommand article, CancellationToken cancellationToken)
        {
            var caracteristique = await GetCaracteristiqueAsync(article.CaracteristiqueId);
            if (!caracteristique.HasPosition)
            {
                article.Position = null;
                return true;
            }
            return article.Position != null;

        }

        private async Task<Domain.Caracteristique> GetCaracteristiqueAsync(Guid id)
        {
            return await _caracteristiqueRepository.GetByIdAsync(id);
        }

    }
}
