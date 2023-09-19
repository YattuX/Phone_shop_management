using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Particularite.Command.UpdateParticularite
{
    public class UpdateParticulariteCommandHandler: IRequestHandler<UpdateParticulariteCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly IParticulariteRepository _particulariteRepository;
        public UpdateParticulariteCommandHandler(IParticulariteRepository particularite, IMapper mapper) 
        {
            _particulariteRepository = particularite;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateParticulariteCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateParticulariteCommandValidator(_particulariteRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var particularite = await _particulariteRepository.GetByIdAsync(request.Id);

            particularite.Content = request.Content;
            
            await _particulariteRepository.UpdateAsync(particularite);
            return Unit.Value;
        }
    }
}
