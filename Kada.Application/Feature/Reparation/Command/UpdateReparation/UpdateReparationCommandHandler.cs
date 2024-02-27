using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using Kada.Application.Feature.Reparation.Command.UpdateReparation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Reparation.Command.UpdateReparation
{
    public class UpdateReparationCommandHandler : IRequestHandler<UpdateReparationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IReparationRepository _reparationRepository;

        public UpdateReparationCommandHandler(IMapper mapper, IReparationRepository reparationRepository)
        {
            _mapper = mapper;
            _reparationRepository = reparationRepository;
        }
        public async Task<Unit> Handle(UpdateReparationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateReparationCommandValidator(_reparationRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var reparation = await _reparationRepository.GetByIdAsync(request.Id);

            _mapper.Map(request, reparation);

            await _reparationRepository.UpdateAsync(reparation);
            return Unit.Value;
        }
    }
}
