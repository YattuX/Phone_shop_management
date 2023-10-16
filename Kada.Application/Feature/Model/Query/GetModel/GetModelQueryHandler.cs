using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Model.Query.GetModel
{
    public class GetModelQueryHandler: IRequestHandler<GetModelQuery,SearchResult<ModelDTO>>
    {
        private readonly IModelRepository _modelRepository;
        private readonly ICaracteristiqueRepository _caracteristiqueRepository;
        private readonly ITypeArticleRepository _typeArticleRepository;

        public GetModelQueryHandler(IModelRepository modelRepository, ICaracteristiqueRepository caracteristiqueRepository, ITypeArticleRepository typeArticleRepository)
        {
            _modelRepository = modelRepository;
            _caracteristiqueRepository = caracteristiqueRepository;
            _typeArticleRepository = typeArticleRepository;
        }

        public async Task<SearchResult<ModelDTO>> Handle(GetModelQuery request, CancellationToken cancellationToken)
        {
            return await GetModelListPageAsync(request.Search.PageIndex, request.Search.PageSize, request.Search.Filters);
        }

        public async Task<SearchResult<ModelDTO>> GetModelListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters)
        {
            var filteredRequest = GetFilteredQuery(filters);
            var filteredModel = (pageIndex == -1) ? filteredRequest.ToList() : filteredRequest.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var rows = new List<ModelDTO>();

            foreach (Domain.Model model in filteredModel)
            {
                rows.Add(new ModelDTO
                {
                    Id = model.Id,
                    Name = model.Name,
                    MarqueId = model.MarqueId,
                    MarqueName = model.Marque.Name
                });
            }

            return new SearchResult<ModelDTO>
            {
                Page = pageIndex,
                CountPerPage = pageSize,
                TotalCount = filteredRequest.Count(),
                Results = rows
            };
        }

        public IQueryable<Domain.Model> GetFilteredQuery(Dictionary<string, string> filter)
        {
            IQueryable<Domain.Model> models = _modelRepository.GetQuery("Marque");

            foreach (var key in filter.Keys)
            {
                if (string.IsNullOrEmpty(filter[key]))
                {
                    continue;
                }

                switch (key)
                {
                    case "name":
                        models = _modelRepository.FilterQuery(models, x => x.Name.ToLower().Contains(filter[key].ToLower()));
                        break;
                    case "marque":
                        models = _modelRepository.FilterQuery(models, x => x.MarqueId.Equals(Guid.Parse(filter[key])));
                        break;
                    case "notCaracteritique":
                        var hasNotCaracteristique = bool.Parse(filter[key]);
                        var modelWithCaracteristiques = _caracteristiqueRepository.GetQuery().Select(v=>v.ModelId).ToList();
                        models = _modelRepository.FilterQuery(models,x=> hasNotCaracteristique?(!modelWithCaracteristiques.Contains(x.Id)): modelWithCaracteristiques.Contains(x.Id));
                        break;
                    case "typeArticle":
                        var typeArticle = _typeArticleRepository.GetQuery().Where(x => x.Name.ToLower().Contains(filter[key].ToLower())).FirstOrDefault();
                        if(typeArticle != null)
                        {
                            models = _modelRepository.FilterQuery(models, x => x.Marque.TypeArticleId == typeArticle.Id);
                        }
                        break;
                }
            }
            return models;
        }
    }
}
