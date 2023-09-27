using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Marque.Command.CreateMarque
{
    public class CreateMarqueCommandHandler: IRequestHandler<CreateMarqueCommand,Guid>
    {
        private IMarqueRepository _marqueRepository;
        private ITypeArticleRepository _typeArticleRepository;
        private IMapper _mapper;
        public CreateMarqueCommandHandler(IMarqueRepository marqueRepository, IMapper mapper, ITypeArticleRepository typeArticleRepository)
        {
            _marqueRepository = marqueRepository;
            _mapper = mapper;
            _typeArticleRepository = typeArticleRepository;
        }

        public async Task<Guid> Handle(CreateMarqueCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateMarqueCommandValidator(_marqueRepository, _typeArticleRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var marque = _mapper.Map<Domain.Marque>(request);
            await _marqueRepository.CreateAsync(marque);
            return marque.Id;
        }
    }
}
