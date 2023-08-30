using FluentValidation;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Feature.Client_.Query.GetClientDetails;
using Kada.Application.Feature.Fournisseur.Command.DeleteFournisseur;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Fournisseur.Query.GetFournisseurDetails
{
    public class GetFournisseurDetailsValidator : AbstractValidator<GetFournisseurDetailsQuery>
    {
        private IFournisseurRepository _fournisseurRepository;
        public GetFournisseurDetailsValidator(IFournisseurRepository fournisseurRepository)
        {
            _fournisseurRepository = fournisseurRepository;

            RuleFor(p => p)
                .NotNull()
                .MustAsync(FournisseurExist).WithMessage("This provider doesn't exist");
        }

        public async Task<bool> FournisseurExist(GetFournisseurDetailsQuery command, CancellationToken token)
        {
            return await _fournisseurRepository.ExistsAsync(x => x.Id == command.Id);
        }

    }
}
