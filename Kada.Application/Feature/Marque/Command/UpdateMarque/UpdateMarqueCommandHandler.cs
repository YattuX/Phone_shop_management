using AutoMapper;
using Kada.Application.Contracts.Pesistence;
using Kada.Application.Exceptions;
using MediatR;

namespace Kada.Application.Feature.Marque.Command.UpdateMarque
{
    public class UpdateMarqueCommandHandler: IRequestHandler<UpdateMarqueCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly IMarqueRepository _marqueRepository;
        private readonly ITypeArticleRepository _typeArticleRepository;
        public UpdateMarqueCommandHandler(IMarqueRepository marque, IMapper mapper, ITypeArticleRepository typeArticleRepository) 
        {
            _marqueRepository = marque;
            _mapper = mapper;
            _typeArticleRepository = typeArticleRepository;
        }

        public async Task<Unit> Handle(UpdateMarqueCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMarqueCommandValidator(_marqueRepository,_typeArticleRepository);
            var resultValidator = await validator.ValidateAsync(request);
            if (resultValidator.Errors.Any())
            {
                throw new BadRequestException(resultValidator.Errors.FirstOrDefault().ErrorMessage, resultValidator);
            }
            var marque = await _marqueRepository.GetByIdAsync(request.Id);

            marque.Name = request.Name;
            marque.TypeArticleId = request.TypeArticleId;
            
            await _marqueRepository.UpdateAsync(marque);
            return Unit.Value;
        }
    }
}
