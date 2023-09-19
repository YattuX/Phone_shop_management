using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Model.Command.CreateModel
{
    public class CreateModelCommandHandler: IRequestHandler<CreateModelCommand,Guid>
    {
        private IModelRepository _modelRepository;
        private IMarqueRepository _marqueRepository;
        private IMapper _mapper;
        public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper, IMarqueRepository marqueRepository)
        {
            _modelRepository = modelRepository;
            _mapper = mapper;
            _marqueRepository = marqueRepository;
        }

        public async Task<Guid> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateModelCommandValidator(_modelRepository, _marqueRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if(resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var model = _mapper.Map<Domain.Model>(request);
            await _modelRepository.CreateAsync(model);
            return model.Id;
        }
    }
}
