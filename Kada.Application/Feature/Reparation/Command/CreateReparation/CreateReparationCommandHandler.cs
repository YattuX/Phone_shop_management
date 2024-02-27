using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using Kada.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Reparation.Command.CreateReparation
{
    public class CreateReparationCommandHandler : IRequestHandler<CreateReparationCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IReparationRepository _reparationRepository;

        public CreateReparationCommandHandler(IMapper mapper, IReparationRepository reparationRepository)
        {
            _mapper = mapper;
            _reparationRepository = reparationRepository;
        }
        public async Task<Guid> Handle(CreateReparationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateReparationCommandValidator(_reparationRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }

            var reparation = _mapper.Map<Domain.Reparation>(request);
            await _reparationRepository.CreateAsync(reparation);
            return reparation.Id;
        }
    }
}
