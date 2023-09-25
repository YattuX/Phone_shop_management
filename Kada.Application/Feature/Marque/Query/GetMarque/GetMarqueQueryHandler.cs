using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Marque.Query.GetMarque
{
    public class GetMarqueQueryHandler: IRequestHandler<GetMarqueQuery,SearchResult<MarqueDTO>>
    {
        private readonly IMarqueRepository _marqueRepository;

        public GetMarqueQueryHandler(IMarqueRepository marqueRepository)
        {
            _marqueRepository = marqueRepository;
        }

        public async Task<SearchResult<MarqueDTO>> Handle(GetMarqueQuery request, CancellationToken cancellationToken)
        {
            return await GetMarqueListPageAsync(request.Search.PageIndex, request.Search.PageSize, request.Search.Filters);
        }

        public async Task<SearchResult<MarqueDTO>> GetMarqueListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters)
        {
            var filteredRequest = GetFilteredQuery(filters);
            var filteredMarque = (pageIndex == -1) ? filteredRequest.ToList() : filteredRequest.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var rows = new List<MarqueDTO>();

            foreach (Domain.Marque marque in filteredMarque)
            {
                rows.Add(new MarqueDTO
                {
                    Id = marque.Id,
                    Name = marque.Name,
                    TypeArticleId = marque.TypeArticleId,
                    TypeArticleName = marque.TypeArticle.Name
                });
            }

            return new SearchResult<MarqueDTO>
            {
                Page = pageIndex,
                CountPerPage = pageSize,
                TotalCount = filteredRequest.Count(),
                Results = rows
            };
        }

        public IQueryable<Domain.Marque> GetFilteredQuery(Dictionary<string, string> filter)
        {
            IQueryable<Domain.Marque> marques = _marqueRepository.GetQuery("TypeArticle");

            foreach (var key in filter.Keys)
            {
                if (string.IsNullOrEmpty(filter[key]))
                {
                    continue;
                }

                switch (key)
                {
                    case "name":
                        marques = _marqueRepository.FilterQuery(marques, x => x.Name.ToLower().Contains(filter[key].ToLower()));
                        break;
                    case "typeArticle":
                        marques = _marqueRepository.FilterQuery(marques, x => x.TypeArticleId.Equals(Guid.Parse(filter[key])));
                        break;
                }
            }
            return marques;
        }
    }
}
