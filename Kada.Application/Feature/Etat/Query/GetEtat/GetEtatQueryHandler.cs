using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Etat.Query.GetEtat
{
    public class GetEtatQueryHandler: IRequestHandler<GetEtatQuery,SearchResult<EtatDTO>>
    {
        private readonly IEtatRepository _etatRepository;

        public GetEtatQueryHandler(IEtatRepository etatRepository)
        {
            _etatRepository = etatRepository;
        }

        public async Task<SearchResult<EtatDTO>> Handle(GetEtatQuery request, CancellationToken cancellationToken)
        {
            return await GetEtatListPageAsync(request.Search.PageIndex, request.Search.PageSize, request.Search.Filters);
        }

        public async Task<SearchResult<EtatDTO>> GetEtatListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters)
        {
            var filteredRequest = GetFilteredQuery(filters);
            var filteredEtat = (pageIndex == -1) ? filteredRequest.ToList() : filteredRequest.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var rows = new List<EtatDTO>();

            foreach (Domain.Etat etat in filteredEtat)
            {
                rows.Add(new EtatDTO
                {
                    Id = etat.Id,
                    Content = etat.Content,
                });
            }

            return new SearchResult<EtatDTO>
            {
                Page = pageIndex,
                CountPerPage = pageSize,
                TotalCount = filteredRequest.Count(),
                Results = rows
            };
        }

        public IQueryable<Domain.Etat> GetFilteredQuery(Dictionary<string, string> filter)
        {
            IQueryable<Domain.Etat> etats = _etatRepository.GetQuery();

            foreach (var key in filter.Keys)
            {
                if (string.IsNullOrEmpty(filter[key]))
                {
                    continue;
                }

                switch (key)
                {
                    case "content":
                        etats = _etatRepository.FilterQuery(etats, x => x.Content.ToLower().Contains(filter[key].ToLower()));
                        break;
                }
            }
            return etats;
        }
    }
}
