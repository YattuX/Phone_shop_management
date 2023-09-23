using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Particularite.Query.GetParticularite
{
    public class GetParticulariteQueryHandler: IRequestHandler<GetParticulariteQuery,SearchResult<ParticulariteDTO>>
    {
        private readonly IParticulariteRepository _particulariteRepository;

        public GetParticulariteQueryHandler(IParticulariteRepository particulariteRepository)
        {
            _particulariteRepository = particulariteRepository;
        }

        public async Task<SearchResult<ParticulariteDTO>> Handle(GetParticulariteQuery request, CancellationToken cancellationToken)
        {
            return await GetParticulariteListPageAsync(request.Search.PageIndex, request.Search.PageSize, request.Search.Filters);
        }

        public async Task<SearchResult<ParticulariteDTO>> GetParticulariteListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters)
        {
            var filteredRequest = GetFilteredQuery(filters);
            var filteredParticularite = (pageIndex == -1) ? filteredRequest.ToList() : filteredRequest.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var rows = new List<ParticulariteDTO>();

            foreach (Domain.Particularite particularite in filteredParticularite)
            {
                rows.Add(new ParticulariteDTO
                {
                    Id = particularite.Id,
                    Content = particularite.Content,
                });
            }

            return new SearchResult<ParticulariteDTO>
            {
                Page = pageIndex,
                CountPerPage = pageSize,
                TotalCount = filteredRequest.Count(),
                Results = rows
            };
        }

        public IQueryable<Domain.Particularite> GetFilteredQuery(Dictionary<string, string> filter)
        {
            IQueryable<Domain.Particularite> particularites = _particulariteRepository.GetQuery();

            foreach (var key in filter.Keys)
            {
                if (string.IsNullOrEmpty(filter[key]))
                {
                    continue;
                }

                switch (key)
                {
                    case "content":
                        particularites = _particulariteRepository.FilterQuery(particularites, x => x.Content.ToLower().Contains(filter[key].ToLower()));
                        break;
                }
            }
            return particularites;
        }
    }
}
