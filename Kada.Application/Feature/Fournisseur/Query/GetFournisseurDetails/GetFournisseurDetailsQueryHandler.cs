using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.DTOs;
using Kada.Application.Exceptions;
using Kada.Application.Feature.Client_.Query.GetClientDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Fournisseur.Query.GetFournisseurDetails
{
    public class GetFournisseurDetailsQueryHandler : IRequestHandler<GetFournisseurDetailsQuery, FournisseurDto>
    {
        IFournisseurRepository _fournisseurRepository;
        IMapper _map;
        public GetFournisseurDetailsQueryHandler(IFournisseurRepository fournisseurRepoistory, IMapper map)
        {
            _map = map;
            _fournisseurRepository = fournisseurRepoistory;
        }

        public async Task<FournisseurDto> Handle(GetFournisseurDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetFournisseurDetailsValidator(_fournisseurRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException("This provider does not exist", resultValidator);
            }

            var fournisseur = await _fournisseurRepository.GetByIdAsync(request.Id);
            return _map.Map<FournisseurDto>(fournisseur);
        }
    }
}
