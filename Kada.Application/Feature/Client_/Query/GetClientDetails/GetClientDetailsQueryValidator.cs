using FluentValidation;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Feature.Client_.Command.DeleteClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Client_.Query.GetClientDetails
{
    public class GetClientDetailsQueryValidator : AbstractValidator<GetClientDetailsQuery>
    {
        private IClientRepository _clientRepository;
        public GetClientDetailsQueryValidator(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;

            RuleFor(p => p)
                .MustAsync(ClientExist).WithMessage("{PropertyName} does not exit");
        }

        public async Task<bool> ClientExist(GetClientDetailsQuery query, CancellationToken token)
        {
            return await _clientRepository.ExistsAsync(x => x.Id == query.Id);
        }
    }
}
