using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Model.Command.UpdateModel
{
    public class UpdateModelCommandHandler: IRequestHandler<UpdateModelCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly IModelRepository _modelRepository;
        private readonly IMarqueRepository _marqueRepository;
        public UpdateModelCommandHandler(IModelRepository model, IMapper mapper, IMarqueRepository marqueRepository) 
        {
            _modelRepository = model;
            _mapper = mapper;
            _marqueRepository = marqueRepository;
        }

        public async Task<Unit> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateModelCommandValidator(_modelRepository,_marqueRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var model = await _modelRepository.GetByIdAsync(request.Id);

            model.Name = request.Name;
            model.MarqueId = request.MarqueId;
            
            await _modelRepository.UpdateAsync(model);
            return Unit.Value;
        }
    }
}
