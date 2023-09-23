using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Couleur.Query.GetCouleur
{
    public class GetCouleurQueryHandler: IRequestHandler<GetCouleurQuery,SearchResult<CouleurDTO>>
    {
        private readonly ICouleurRepository _couleurRepository;

        public GetCouleurQueryHandler(ICouleurRepository couleurRepository)
        {
            _couleurRepository = couleurRepository;
        }

        public async Task<SearchResult<CouleurDTO>> Handle(GetCouleurQuery request, CancellationToken cancellationToken)
        {
            return await GetCouleurListPageAsync(request.Search.PageIndex, request.Search.PageSize, request.Search.Filters);
        }

        public async Task<SearchResult<CouleurDTO>> GetCouleurListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters)
        {
            var filteredRequest = GetFilteredQuery(filters);
            var filteredCouleur = (pageIndex == -1) ? filteredRequest.ToList() : filteredRequest.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var rows = new List<CouleurDTO>();

            foreach (Domain.Couleur couleur in filteredCouleur)
            {
                rows.Add(new CouleurDTO
                {
                    Id = couleur.Id,
                    Name = couleur.Name,
                    CodeCouleur = couleur.CodeCouleur,
                });
            }

            return new SearchResult<CouleurDTO>
            {
                Page = pageIndex,
                CountPerPage = pageSize,
                TotalCount = filteredRequest.Count(),
                Results = rows
            };
        }

        public IQueryable<Domain.Couleur> GetFilteredQuery(Dictionary<string, string> filter)
        {
            IQueryable<Domain.Couleur> couleurs = _couleurRepository.GetQuery();

            foreach (var key in filter.Keys)
            {
                if (string.IsNullOrEmpty(filter[key]))
                {
                    continue;
                }

                switch (key)
                {
                    case "name":
                        couleurs = _couleurRepository.FilterQuery(couleurs, x => x.Name.ToLower().Contains(filter[key].ToLower()));
                        break;
                    case "code":
                        couleurs = _couleurRepository.FilterQuery(couleurs, x => x.CodeCouleur.ToLower().Contains(filter[key].ToLower()));
                        break;
                }
            }
            return couleurs;
        }
    }
}
