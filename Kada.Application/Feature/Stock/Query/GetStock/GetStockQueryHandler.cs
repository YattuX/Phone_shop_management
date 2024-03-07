using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using Kada.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Stock.Query.GetStock
{
    public class GetStockQueryHandler : IRequestHandler<GetStockQuery, SearchResult<StockDTO>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public GetStockQueryHandler(
            IStockRepository stockRepository,
            IMapper mapper
            )
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public async Task<SearchResult<StockDTO>> Handle(GetStockQuery request, CancellationToken cancellationToken)
        {
            return await GetStockListPageAsync(request.Search.PageIndex, request.Search.PageSize, request.Search.Filters);
        }

        public async Task<SearchResult<StockDTO>> GetStockListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters)
        {
            var filteredRequest = GetFilteredQuery(filters);
            var filteredStock = (pageIndex == -1) ? filteredRequest.ToList() : filteredRequest.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var rows = new List<StockDTO>();

            foreach (Domain.Stock stock in filteredStock)
            {
                rows.Add(new StockDTO
                {
                    Id = stock.Id,
                    TypeName = stock.Type == TypeStockage.entree ? "Entrée" : "Sortie",
                    Quantite = stock.Quantite,
                    ArticleId = stock.ArticleId,
                    Type = stock.Type,
                    StatusName = stock.Status == Status.Active ? "Actif" : "Non Actif",
                    Article = _mapper.Map<ArticleDTO>(stock.Article),
                    ArticleName = _mapper.Map<ModelDTO>(stock.Article?.Caracteristique?.Model).Name,
                    CreationDate = stock.DateCreated
                });
            }

            return new SearchResult<StockDTO>
            {
                Page = pageIndex,
                CountPerPage = pageSize,
                TotalCount = filteredRequest.Count(),
                Results = rows
            };
        }

        public IQueryable<Domain.Stock> GetFilteredQuery(Dictionary<string, string> filter)
        {
            IQueryable<Domain.Stock> stocks = _stockRepository.GetQuery("Article.Caracteristique.Model");

            foreach (var key in filter.Keys)
            {
                if (string.IsNullOrEmpty(filter[key]))
                {
                    continue;
                }

                switch (key)
                {
                    case "articleId":
                        stocks = _stockRepository.FilterQuery(stocks, x => x.ArticleId == new Guid(filter[key]));
                        break;
                    case "typeMouvement":
                        stocks = _stockRepository.FilterQuery(stocks, x => x.Type == (TypeStockage)int.Parse(filter[key]));
                        break;
                }
            }
            return stocks;
        }
    }
}
