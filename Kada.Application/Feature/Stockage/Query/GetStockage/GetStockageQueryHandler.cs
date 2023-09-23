using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Stockage.Query.GetStockage
{
    public class GetStockageQueryHandler: IRequestHandler<GetStockageQuery,SearchResult<StockageDTO>>
    {
        private readonly IStockageRepository _stockageRepository;

        public GetStockageQueryHandler(IStockageRepository stockageRepository)
        {
            _stockageRepository = stockageRepository;
        }

        public async Task<SearchResult<StockageDTO>> Handle(GetStockageQuery request, CancellationToken cancellationToken)
        {
            return await GetStockageListPageAsync(request.Search.PageIndex, request.Search.PageSize, request.Search.Filters);
        }

        public async Task<SearchResult<StockageDTO>> GetStockageListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters)
        {
            var filteredRequest = GetFilteredQuery(filters);
            var filteredStockage = (pageIndex == -1) ? filteredRequest.ToList() : filteredRequest.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var rows = new List<StockageDTO>();

            foreach (Domain.Stockage stockage in filteredStockage)
            {
                rows.Add(new StockageDTO
                {
                    Id = stockage.Id,
                    Name = stockage.Name,
                });
            }

            return new SearchResult<StockageDTO>
            {
                Page = pageIndex,
                CountPerPage = pageSize,
                TotalCount = filteredRequest.Count(),
                Results = rows
            };
        }

        public IQueryable<Domain.Stockage> GetFilteredQuery(Dictionary<string, string> filter)
        {
            IQueryable<Domain.Stockage> stockages = _stockageRepository.GetQuery();

            foreach (var key in filter.Keys)
            {
                if (string.IsNullOrEmpty(filter[key]))
                {
                    continue;
                }

                switch (key)
                {
                    case "name":
                        stockages = _stockageRepository.FilterQuery(stockages, x => x.Name.ToLower().Contains(filter[key].ToLower()));
                        break;
                }
            }
            return stockages;
        }
    }
}
