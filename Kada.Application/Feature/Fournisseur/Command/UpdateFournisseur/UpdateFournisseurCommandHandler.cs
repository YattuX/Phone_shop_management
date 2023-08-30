using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using Kada.Application.Feature.Client_.Command.UpdateClient;
using Kada.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Fournisseur.Command.UpdateFournisseur
{
    public class UpdateFournisseurCommandHandler : IRequestHandler<UpdateFournisseurCommand, Unit>
    {
        IMapper _map;
        IFournisseurRepository _fournisseurRepository;
        public UpdateFournisseurCommandHandler(IFournisseurRepository fournisseurRepository, IMapper map) 
        {
            _fournisseurRepository= fournisseurRepository;
            _map= map;
        }

        public async Task<Unit> Handle(UpdateFournisseurCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFournisseurCommandValidator(_fournisseurRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException("Invalid Fournisseur", resultValidator);
            }
            var fournisseur = await  _fournisseurRepository.GetByIdAsync(request.Id);

            fournisseur.Name = request.Name;
            fournisseur.LastName = request.LastName;
            fournisseur.WhatsappNumber = request.WhatsappNumber;
            fournisseur.Email = request.Email;

            await _fournisseurRepository.UpdateAsync(fournisseur);
            return Unit.Value;
        }
    }
}
