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
                    HasCamera= caracteristique.HasCamera,
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
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasStockage == bool.Parse(filter[key]));
                        break;
                    case "hasCouleur":
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasCouleur == bool.Parse(filter[key]));
                        break;
                    case "hasNombreDeSim":
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasNombreDeSim == bool.Parse(filter[key]));
                        break;
                    case "hasImei":
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasImei == bool.Parse(filter[key]));
                        break;
                    case "hasParticularite":
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasParticularite == bool.Parse(filter[key]));
                        break;
                    case "hasEtat":
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasEtat == bool.Parse(filter[key]));
                        break;
                    case "hasProcesseurs":
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasProcesseurs == bool.Parse(filter[key]));
                        break;
                    case "hasTailleEcran":
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasTailleEcran == bool.Parse(filter[key]));
                        break;
                    case "hasRam":
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasRam == bool.Parse(filter[key]));
                        break;
                    case "hasQualite":
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasQualite == bool.Parse(filter[key]));
                        break;
                    case "hasType":
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasType == bool.Parse(filter[key]));
                        break;
                    case "hasCapacite":
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasCapacite == bool.Parse(filter[key]));
                        break;
                    case "hasCaracteristic":
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasCaracteristic == bool.Parse(filter[key]));
                        break;
                    case "hasPuissance":
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasPuissance == bool.Parse(filter[key]));
                        break;
                    case "hasCamera":
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.HasCamera == bool.Parse(filter[key]));
                        break;
                    
                    case "model":
                        caracteristiques = _caracteristiqueRepository.FilterQuery(caracteristiques, x => x.ModelId.Equals(filter[key]));
                        break;
                }
            }
            return caracteristiques;
        }
    }
}
