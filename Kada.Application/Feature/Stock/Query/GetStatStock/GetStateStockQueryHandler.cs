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

namespace Kada.Application.Feature.Stock.Query.GetStatStock
{
    public class GetStateStockQueryHandler : IRequestHandler<GetStatStockQuery, SearchResult<StateStockDTO>>
    {
        private readonly IStockRepository _stockRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly IMapper _mapper;
        public GetStateStockQueryHandler(
            IStockRepository stockRepository,
            IArticleRepository articleRepository,
            IMapper mapper
            ) 
        {
            _stockRepository = stockRepository;
            _articleRepository = articleRepository;
            _mapper = mapper;
        }
        public async Task<SearchResult<StateStockDTO>> Handle(GetStatStockQuery request, CancellationToken cancellationToken)
        {
            return await GetStateStockListPageAsync(request.Search.PageIndex, request.Search.PageSize, request.Search.Filters);
        }
        public async Task<SearchResult<StateStockDTO>> GetStateStockListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters)
        {
            var filteredRequest = GetFilteredQuery(filters);
            var filteredStateStock = (pageIndex == -1) ? filteredRequest.ToList() : filteredRequest.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var rows = new List<StateStockDTO>();

            foreach (var article in filteredStateStock)
            {
                rows.Add(new StateStockDTO
                {
                    Id = article.Id,
                   ArticleName  = article.ArticleName,
                   QuantiteRestante = article.QuantiteRestante
                });
            }

            return new SearchResult<StateStockDTO>
            {
                Page = pageIndex,
                CountPerPage = pageSize,
                TotalCount = filteredRequest.Count(),
                Results = rows
            };
        }

        public IQueryable<StateStockDTO> GetFilteredQuery(Dictionary<string, string> filter)
        {
            IQueryable<Domain.Stock> stocks = _stockRepository.GetQuery("Article.Caracteristique.Model");
            IQueryable<Domain.Article> articles = _articleRepository.GetQuery("Caracteristique.Model");
            IQueryable<StateStockDTO> stockItem = articles.Select(article => new StateStockDTO
            {
                Id = article.Id,
                ArticleName = article.Caracteristique.Model.Name,
                QuantiteRestante = stocks
                                    .Where(s => s.ArticleId == article.Id && s.Type == TypeStockage.entree)
                                    .Sum(x => x.Quantite) - stocks
                                                            .Where(s => s.ArticleId == article.Id && s.Type == TypeStockage.sortie)
                                                            .Sum(x => x.Quantite)
            }); 
           

            foreach (var key in filter.Keys)
            {
                if (string.IsNullOrEmpty(filter[key]))
                {
                    continue;
                }

                switch (key)
                {
                    case "articleId":
                        stockItem = stockItem.Where(x => x.Id == new Guid(filter[key]));
                        break;
                }
            }
            return stockItem;
        }

    }


}
