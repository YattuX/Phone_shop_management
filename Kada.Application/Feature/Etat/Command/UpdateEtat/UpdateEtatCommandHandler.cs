using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Etat.Command.UpdateEtat
{
    public class UpdateEtatCommandHandler: IRequestHandler<UpdateEtatCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEtatRepository _etatRepository;
        public UpdateEtatCommandHandler(IEtatRepository etat, IMapper mapper) 
        {
            _etatRepository = etat;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEtatCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEtatCommandValidator(_etatRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var etat = await _etatRepository.GetByIdAsync(request.Id);

            etat.Content = request.Content;
            
            await _etatRepository.UpdateAsync(etat);
            return Unit.Value;
        }
    }
}
