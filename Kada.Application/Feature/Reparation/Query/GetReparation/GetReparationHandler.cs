using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using Kada.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Reparation.Query.GetReparation
{
    public class GetReparationHandler : IRequestHandler<GetReparationQuery, SearchResult<ReparationDTO>>
    {
        private readonly IReparationRepository _reparationRepository;
        private readonly IMapper _mapper;

        public GetReparationHandler(IReparationRepository reparationRepository, IMapper mapper)
        {
            _reparationRepository = reparationRepository;
            _mapper = mapper;
        }
        public async Task<SearchResult<ReparationDTO>> Handle(GetReparationQuery request, CancellationToken cancellationToken)
        {
            return await GetReparationListPageAsync(request.Search.PageIndex, request.Search.PageSize, request.Search.Filters);
        }


        public async Task<SearchResult<ReparationDTO>> GetReparationListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters)
        {
            var filteredRequest = GetFilteredQuery(filters);
            var filteredReparation = (pageIndex == -1) ? filteredRequest.ToList() : filteredRequest.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            
            var rows = _mapper.Map<List<ReparationDTO>>(filteredReparation);

            return new SearchResult<ReparationDTO>
            {
                Page = pageIndex,
                CountPerPage = pageSize,
                TotalCount = filteredRequest.Count(),
                Results = rows
            };
        }

        public IQueryable<Domain.Reparation> GetFilteredQuery(Dictionary<string, string> filter)
        {
            IQueryable<Domain.Reparation> reparations = _reparationRepository.GetQuery("Client,Article.Caracteristique.Model");

            foreach (var key in filter.Keys)
            {
                if (string.IsNullOrEmpty(filter[key]))
                {
                    continue;
                }

                switch (key)
                {
                    case "clientId":
                        if (Guid.TryParse(filter[key], out var idClient))
                        {
                            reparations = reparations.Where(x => x.ClientId == idClient);
                        }
                        break;
                    case "articleId":
                        if (Guid.TryParse(filter[key], out var articleId))
                        {
                            reparations = reparations.Where(x => x.ArticleId == articleId);
                        }
                        break;
                    case "description":
                        reparations = reparations.Where(x => x.DescriptionProbleme.ToLower().Contains(filter[key].ToLower()));
                        break;
                    case "dateDepot":
                        if (DateTime.TryParse(filter[key], out var dateDepot))
                        {
                            reparations = reparations.Where(x => x.DateDepot.Date == dateDepot.Date);
                        }
                        break;
                    case "dateLivraison":
                        if (DateTime.TryParse(filter[key], out var dateLivraison))
                        {
                            reparations = reparations.Where(x => x.DateLivraison.HasValue && x.DateLivraison.Value.Date == dateLivraison.Date);
                        }
                        break;
                    case "etatReparation":
                        EtatReparation etatReparation;
                        if (Enum.TryParse(filter[key], true, out etatReparation))
                        {
                            reparations = reparations.Where(x => x.EtatReparation == etatReparation);
                        }
                        break;
                    case "statutPaiement":
                        StatutPaiement statutPaiement;
                        if (Enum.TryParse(filter[key], true, out statutPaiement))
                        {
                            reparations = reparations.Where(x => x.StatutPaiement == statutPaiement);
                        }
                        break;
                    case "coutReparation":
                        decimal coutReparation;
                        if (decimal.TryParse(filter[key], out coutReparation))
                        {
                            reparations = reparations.Where(x => x.CoutReparation == coutReparation);
                        }
                        break;
                    case "reparateurEnCharge":
                        reparations = reparations.Where(x => x.ReparateurEnCharge == filter[key]);
                        break;
                }
            }
            return reparations;
        }

    }
}
