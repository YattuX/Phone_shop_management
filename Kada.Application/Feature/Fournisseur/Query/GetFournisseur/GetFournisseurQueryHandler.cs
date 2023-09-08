using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using Kada.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Fournisseur.Query.GetFournisseur
{
    public class GetFournisseurQueryHandler : IRequestHandler<GetFournisseurQuery, SearchResult<FournisseurDto>>
    {
        private IFournisseurRepository _fournisseurRepository;
        private IMapper _map;

        public GetFournisseurQueryHandler(IFournisseurRepository fournisseurRepository, IMapper map)
        {
            _fournisseurRepository = fournisseurRepository;
            _map = map;
        }

        public async Task<SearchResult<FournisseurDto>> Handle(GetFournisseurQuery request, CancellationToken cancellationToken)
        {
            return await GetFournisseurListPageAsync(request.Search.PageIndex, request.Search.PageSize, request.Search.Filters);
        }

        public async Task<SearchResult<FournisseurDto>> GetFournisseurListPageAsync(int pageIndex, int pageSize, Dictionary<string, string> filters)
        {
            var filteredRequest = GetFilteredQuery(filters);
            var filteredFournisseur = (pageIndex == -1) ? filteredRequest.ToList() : filteredRequest.Skip(pageIndex * pageSize).Take(pageSize).ToList();
            var rows = new List<FournisseurDto>();

            foreach (Domain.Fournisseur fournisseur in filteredFournisseur)
            {
                rows.Add(new FournisseurDto
                {
                    Id = fournisseur.Id,
                    Name = fournisseur.Name,
                    LastName = fournisseur.LastName,
                    Email = fournisseur.Email,
                    WhatsappNumber = fournisseur.WhatsappNumber,
                    Identifiant = fournisseur.Identifiant
                });
            }

            return new SearchResult<FournisseurDto>
            {
                Page = pageIndex,
                CountPerPage = pageSize,
                TotalCount = filteredRequest.Count(),
                Results = rows
            };
        }

        public IQueryable<Domain.Fournisseur> GetFilteredQuery(Dictionary<string, string> filter)
        {
            IQueryable<Domain.Fournisseur> fournisseurQuery = _fournisseurRepository.GetQuery();

            foreach (var key in filter.Keys)
            {
                if (string.IsNullOrEmpty(filter[key]))
                {
                    continue;
                }

                switch (key)
                {
                    case "name":
                        fournisseurQuery = _fournisseurRepository.FilterQuery(fournisseurQuery, x => x.Name.StartsWith(filter[key]));
                        break;
                    case "lastName":
                        fournisseurQuery = _fournisseurRepository.FilterQuery(fournisseurQuery, x => x.LastName.StartsWith(filter[key]));
                        break;
                    case "whatsappNumber":
                        fournisseurQuery = _fournisseurRepository.FilterQuery(fournisseurQuery, x => x.WhatsappNumber.StartsWith(filter[key]));
                        break;
                    case "identifiant":
                        fournisseurQuery = _fournisseurRepository.FilterQuery(fournisseurQuery, x => x.Identifiant.StartsWith(filter[key]));
                        break;
                    case "email":
                        fournisseurQuery = _fournisseurRepository.FilterQuery(fournisseurQuery, x=> x.Email.Contains(filter[key]));
                        break;
                }
            }
            return fournisseurQuery;
        }
    }
}
