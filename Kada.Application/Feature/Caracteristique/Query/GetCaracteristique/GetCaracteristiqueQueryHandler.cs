using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Caracteristique.Query.GetCaracteristique
{
    public class GetCaracteristiqueQueryHandler: IRequestHandler<GetCaracteristiqueQuery,SearchResult<CaracteristiqueDTO>>
    {
        private readonly ICaracteristiqueRepository _caracteristiqueRepository;

        public GetCaracteristiqueQueryHandler(ICaracteristiqueRepository caracteristiqueRepository)
        {
            _caracteristiqueRepository = caracteristiqueRepository;
        }

        public async Task<SearchResult<CaracteristiqueDTO>> Handle(GetCaracteristiqueQuery request, CancellationToken cancellationToken)
        {
            return await GetCaracteristiqueListPageAsync(request.Search.PageIndex, request.Search.PageSize, request.Search.Filters);
        }

        public async Task<SearchResult<CaracteristiqueDTO>> GetCaracteristiqueListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters)
        {
            var filteredRequest = GetFilteredQuery(filters);
            var filteredCaracteristique = (pageIndex == -1) ? filteredRequest.ToList() : filteredRequest.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var rows = new List<CaracteristiqueDTO>();

            foreach (Domain.Caracteristique caracteristique in filteredCaracteristique)
            {
                rows.Add(new CaracteristiqueDTO
                {
                    Id = caracteristique.Id,
                    ModelName = caracteristique.Model.Name,
                    ModelId = caracteristique.ModelId,
                    HasStockage= caracteristique.HasStockage,
                    HasCouleur = caracteristique.HasCouleur,
                    HasNombreDeSim= caracteristique.HasNombreDeSim,
                    HasImei= caracteristique.HasImei,
                    HasParticularite= caracteristique.HasParticularite,
                    HasEtat= caracteristique.HasEtat,
                    HasProcesseurs= caracteristique.HasProcesseurs,
                    HasTailleEcran= caracteristique.HasTailleEcran,
                    HasRam= caracteristique.HasRam,
                    HasQualite= caracteristique.HasQualite,
                    HasType= caracteristique.HasType,
                    HasCapacite= caracteristique.HasCapacite,
                    HasCaracteristic= caracteristique.HasCaracteristic,
                    HasPuissance= caracteristique.HasPuissance,
                    HasPosition= caracteristique.HasPosition,
                    HasDescription = caracteristique.HasDescription,
                });
            }

            return new SearchResult<CaracteristiqueDTO>
            {
                Page = pageIndex,
                CountPerPage = pageSize,
                TotalCount = filteredRequest.Count(),
                Results = rows
            };
        }

        public IQueryable<Domain.Caracteristique> GetFilteredQuery(Dictionary<string, string> filter)
        {
            IQueryable<Domain.Caracteristique> caracteristiques = _caracteristiqueRepository.GetQuery("Model");

            foreach (var key in filter.Keys)
            {
                if (string.IsNullOrEmpty(filter[key]))
                {
                    continue;
                }
                switch (key)
                {
                    case "hasStockage":
                        bool hasStockage = bool.Parse(filter[key]);
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasStockage == hasStockage);
                        break;
                    case "hasCouleur":
                        bool hasCouleur = bool.Parse(filter[key]);
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasCouleur == hasCouleur);
                        break;
                    case "hasNombreDeSim":
                        var hasNombreDeSim = bool.Parse(filter[key]);
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasNombreDeSim == hasNombreDeSim);
                        break;
                    case "hasImei":
                        bool hasImei = bool.Parse(filter[key]);
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasImei == hasImei);
                        break;
                    case "hasParticularite":
                        bool hasParticularite = bool.Parse(filter[key]);
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasParticularite == hasParticularite);
                        break;
                    case "hasEtat":
                        var hasEtat = bool.Parse(filter[key]);
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasEtat == hasEtat);
                        break;
                    case "hasProcesseurs":
                        var hasProcesseurs = bool.Parse(filter[key]);
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasProcesseurs == hasProcesseurs);
                        break;
                    case "hasTailleEcran":
                        var hasTailleEcran = bool.Parse(filter[key]);
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasTailleEcran == hasTailleEcran);
                        break;
                    case "hasRam":
                        var hasRam = bool.Parse(filter[key]);
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasRam == hasRam);
                        break;
                    case "hasQualite":
                        var hasQualite = bool.Parse(filter[key]);
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasQualite == hasQualite);
                        break;
                    case "hasType":
                        var hasType = bool.Parse(filter[key]);
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasType == hasType);
                        break;
                    case "hasCapacite":
                        var hasCapacite = bool.Parse(filter[key]);
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasCapacite == hasCapacite);
                        break;
                    case "hasCaracteristic":
                        var val = bool.Parse(filter[key]);
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasCaracteristic == val);
                        break;
                    case "hasPuissance":
                        var hasPuissance = bool.Parse(filter[key]);
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasPuissance == hasPuissance);
                        break;
                    case "hasPosition":
                        var hasPosition = bool.Parse(filter[key]);
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasPosition == hasPosition);
                        break;
                    case "hasDescription":
                        var hasDescription = bool.Parse(filter[key]);
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasDescription == hasDescription);
                        break;
                    
                    case "model":
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.ModelId.Equals(Guid.Parse(filter[key])));
                        break;
                }
            }
            return caracteristiques;
        }
    }
}
