using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Model.Query.GetModel
{
    public class GetModelQueryHandler: IRequestHandler<GetModelQuery,SearchResult<ModelDTO>>
    {
        private readonly IModelRepository _modelRepository;

        public GetModelQueryHandler(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
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
                        models = _modelRepository.FilterQuery(models, x => x.MarqueId.Equals(filter[key]));
                        break;
                }
            }
            return models;
        }
    }
}
