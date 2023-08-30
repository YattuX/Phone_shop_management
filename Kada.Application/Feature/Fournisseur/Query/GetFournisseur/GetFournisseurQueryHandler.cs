using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Fournisseur.Query.GetFournisseur
{
    public class GetFournisseurQueryHandler : IRequestHandler<GetFournisseurQuery, IReadOnlyList<FournisseurDto>>
    {
        private IFournisseurRepository _fournisseurRepository;
        private IMapper _map;

        public GetFournisseurQueryHandler(IFournisseurRepository fournisseurRepository, IMapper map)
        {
            _fournisseurRepository = fournisseurRepository;
            _map = map;
        }

        public async Task<IReadOnlyList<FournisseurDto>> Handle(GetFournisseurQuery request, CancellationToken cancellationToken)
        {
            var fournisseurList = await _fournisseurRepository.GetAllAsync();
            return _map.Map<IReadOnlyList<FournisseurDto>>(fournisseurList);
        }
    }
}
