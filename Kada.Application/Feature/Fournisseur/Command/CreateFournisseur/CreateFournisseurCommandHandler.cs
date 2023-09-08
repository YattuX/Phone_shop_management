using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using Kada.Application.Utility;
using MediatR;

namespace Kada.Application.Feature.Fournisseur.Command.CreateFournisseur
{
    public class CreateFournisseurCommandHandler : IRequestHandler<CreateFournisseurCommand, Guid>
    {
        private IFournisseurRepository _fournisseurRepository;
        private IMapper _map;
        public CreateFournisseurCommandHandler(IFournisseurRepository fournisseurRepository, IMapper map)
        {
            _fournisseurRepository = fournisseurRepository;
            _map = map;
        }
        public async Task<Guid> Handle(CreateFournisseurCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateFournisseurCommandValidator(_fournisseurRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException("Client Invalid", resultValidator);
            }
            var fournisseur = _map.Map<Domain.Fournisseur>(request);
            var identifiant = Utils.GenerateRandomIdentifier("FRN-");
            var quit = 0;
            while (await _fournisseurRepository.ExistsAsync(x => x.Identifiant == identifiant))
            {
                identifiant = Utils.GenerateRandomIdentifier("CLT-");
                quit++;
                if (quit > 10000)
                {
                    throw new BadRequestException("Identifiant Client already exist, please try again");
                }
            }
            fournisseur.Identifiant = identifiant;
            await _fournisseurRepository.CreateAsync(fournisseur);
            return fournisseur.Id;
        }
    }
}
