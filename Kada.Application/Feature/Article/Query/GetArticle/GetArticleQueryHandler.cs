using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Article.Query.GetArticle
{
    public class GetArticleQueryHandler : IRequestHandler<GetArticleQuery, SearchResult<ArticleDTO>>
    {
        private readonly IArticleRepository _articleRepository;

        public GetArticleQueryHandler(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<SearchResult<ArticleDTO>> Handle(GetArticleQuery request, CancellationToken cancellationToken)
        {
            return await GetArticleListPageAsync(request.Search.PageIndex, request.Search.PageSize, request.Search.Filters);
        }

        public async Task<SearchResult<ArticleDTO>> GetArticleListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters)
        {
            var filteredRequest = GetFilteredQuery(filters);
            var filteredArticle = (pageIndex == -1) ? filteredRequest.ToList() : filteredRequest.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var rows = new List<ArticleDTO>();

            foreach (Domain.Article article in filteredArticle)
            {
                rows.Add(new ArticleDTO
                {
                    Id = article.Id,
                    StockageId = article.StockageId,
                    StockageName = article.Stockage?.Name,
                    CouleurId = article.CouleurId,
                    CouleurName = article.Couleur?.Name,
                    NombreDeSim = article.NombreDeSim,
                    Imei = article.Imei,
                    ParticulariteId = article.ParticulariteId,
                    ParticulariteContent = article.Particularite?.Content,
                    EtatId = article.EtatId,
                    EtatContent = article.Etat?.Content,
                    Processeurs = article.Processeurs,
                    TailleEcran = article.TailleEcran,
                    Ram = article.Ram,
                    Qualite = article.Qualite,
                    Position = article.Position,
                    TypeId = article.TypeId,
                    TypeContent = article.Type?.Content,
                    Capacite = article.Capacite,
                    Puissance = article.Puissance,
                    modele = article.Caracteristique.Model.Name,
                    CaracteristiqueId = article.CaracteristiqueId,
                    Description = article.Description,
                });
            }

            return new SearchResult<ArticleDTO>
            {
                Page = pageIndex,
                CountPerPage = pageSize,
                TotalCount = filteredRequest.Count(),
                Results = rows
            };
        }

        public IQueryable<Domain.Article> GetFilteredQuery(Dictionary<string, string> filter)
        {
            var articles = _articleRepository.GetQuery("Caracteristique.Model.Marque.TypeArticle,Stockage,Couleur,Particularite,Etat,Type");

            foreach (var key in filter.Keys)
            {
                if (string.IsNullOrEmpty(filter[key]))
                {
                    continue;
                }
                switch (key)
                {
                    case "caracteristique":
                        articles = _articleRepository.FilterQuery(articles, x => x.CaracteristiqueId.Equals(filter[key]));
                        break;
                    case "stockage":
                        articles = _articleRepository.FilterQuery(articles, x => x.StockageId.Equals(filter[key]));
                        break;
                    case "couleur":
                        articles = _articleRepository.FilterQuery(articles, x => x.CouleurId.Equals(filter[key]));
                        break;
                    case "particularite":
                        articles = _articleRepository.FilterQuery(articles, x => x.ParticulariteId.Equals(filter[key]));
                        break;
                    case "etat":
                        articles = _articleRepository.FilterQuery(articles, x => x.EtatId.Equals(filter[key]));
                        break;
                    case "type":
                        articles = _articleRepository.FilterQuery(articles, x => x.TypeId.Equals(filter[key]));
                        break;
                    case "imei":
                        articles = _articleRepository.FilterQuery(articles, x => x.Imei.ToLower().Contains(filter[key].ToLower()));
                        break;
                    case "processeurs":
                        articles = _articleRepository.FilterQuery(articles, x => x.Processeurs.ToLower().Contains(filter[key].ToLower()));
                        break;
                    case "tailleEcran":
                        articles = _articleRepository.FilterQuery(articles, x => x.TailleEcran.ToLower().Contains(filter[key].ToLower()));
                        break;
                    case "ram":
                        articles = _articleRepository.FilterQuery(articles, x => x.Ram.ToLower().Contains(filter[key].ToLower()));
                        break;
                    case "qualite":
                        articles = _articleRepository.FilterQuery(articles, x => x.Qualite.ToLower().Contains(filter[key].ToLower()));
                        break;
                    case "position":
                        articles = _articleRepository.FilterQuery(articles, x => x.Position.ToLower().Contains(filter[key].ToLower()));
                        break;
                    case "capacite":
                        articles = _articleRepository.FilterQuery(articles, x => x.Capacite.ToLower().Contains(filter[key].ToLower()));
                        break;
                    case "puissance":
                        articles = _articleRepository.FilterQuery(articles, x => x.Puissance.ToLower().Contains(filter[key].ToLower()));
                        break;
                    case "description":
                        articles = _articleRepository.FilterQuery(articles, x => x.Description.ToLower().Contains(filter[key].ToLower()));
                        break;
                    case "model":
                        articles = _articleRepository.FilterQuery(articles, x => x.Caracteristique.Model.Id.Equals(filter[key]));
                        break;
                    case "typeArticle":
                        articles = _articleRepository.FilterQuery(articles, x => x.Caracteristique.Model.Marque.TypeArticle.Name.ToLower().Contains(filter[key].ToLower()));
                        break;
                }
            }
            return articles;
        }
    }
}
