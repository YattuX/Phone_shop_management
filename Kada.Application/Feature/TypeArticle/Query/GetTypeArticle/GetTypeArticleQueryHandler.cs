using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.TypeArticle.Query.GetTypeArticle
{
    public class GetTypeArticleQueryHandler: IRequestHandler<GetTypeArticleQuery,SearchResult<TypeArticleDTO>>
    {
        private readonly ITypeArticleRepository _typeArticleRepository;

        public GetTypeArticleQueryHandler(ITypeArticleRepository typeArticleRepository)
        {
            _typeArticleRepository = typeArticleRepository;
        }

        public async Task<SearchResult<TypeArticleDTO>> Handle(GetTypeArticleQuery request, CancellationToken cancellationToken)
        {
            return await GetTypeArticleListPageAsync(request.Search.PageIndex, request.Search.PageSize, request.Search.Filters);
        }

        public async Task<SearchResult<TypeArticleDTO>> GetTypeArticleListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters)
        {
            var filteredRequest = GetFilteredQuery(filters);
            var filteredTypeArticle = (pageIndex == -1) ? filteredRequest.ToList() : filteredRequest.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var rows = new List<TypeArticleDTO>();

            foreach (Domain.TypeArticle typeArticle in filteredTypeArticle)
            {
                rows.Add(new TypeArticleDTO
                {
                    Id = typeArticle.Id,
                    Name = typeArticle.Name,
                });
            }

            return new SearchResult<TypeArticleDTO>
            {
                Page = pageIndex,
                CountPerPage = pageSize,
                TotalCount = filteredRequest.Count(),
                Results = rows
            };
        }

        public IQueryable<Domain.TypeArticle> GetFilteredQuery(Dictionary<string, string> filter)
        {
            IQueryable<Domain.TypeArticle> typeArticles = _typeArticleRepository.GetQuery();

            foreach (var key in filter.Keys)
            {
                if (string.IsNullOrEmpty(filter[key]))
                {
                    continue;
                }

                switch (key)
                {
                    case "name":
                        typeArticles = _typeArticleRepository.FilterQuery(typeArticles, x => x.Name.ToLower().Contains(filter[key].ToLower()));
                        break;
                }
            }
            return typeArticles;
        }
    }
}
