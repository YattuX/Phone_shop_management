using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Type_.Query.GetType
{
    public class GetTypeQueryHandler: IRequestHandler<GetTypeQuery,SearchResult<TypeDTO>>
    {
        private readonly ITypeRepository _typeRepository;

        public GetTypeQueryHandler(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public async Task<SearchResult<TypeDTO>> Handle(GetTypeQuery request, CancellationToken cancellationToken)
        {
            return await GetTypeListPageAsync(request.Search.PageIndex, request.Search.PageSize, request.Search.Filters);
        }

        public async Task<SearchResult<TypeDTO>> GetTypeListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters)
        {
            var filteredRequest = GetFilteredQuery(filters);
            var filteredType = (pageIndex == -1) ? filteredRequest.ToList() : filteredRequest.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var rows = new List<TypeDTO>();

            foreach (Domain.Type_ type in filteredType)
            {
                rows.Add(new TypeDTO
                {
                    Id = type.Id,
                    Content = type.Content,
                });
            }

            return new SearchResult<TypeDTO>
            {
                Page = pageIndex,
                CountPerPage = pageSize,
                TotalCount = filteredRequest.Count(),
                Results = rows
            };
        }

        public IQueryable<Domain.Type_> GetFilteredQuery(Dictionary<string, string> filter)
        {
            IQueryable<Domain.Type_> types = _typeRepository.GetQuery();

            foreach (var key in filter.Keys)
            {
                if (string.IsNullOrEmpty(filter[key]))
                {
                    continue;
                }

                switch (key)
                {
                    case "content":
                        types = _typeRepository.FilterQuery(types, x => x.Content.ToLower().Contains(filter[key].ToLower()));
                        break;
                }
            }
            return types;
        }
    }
}
