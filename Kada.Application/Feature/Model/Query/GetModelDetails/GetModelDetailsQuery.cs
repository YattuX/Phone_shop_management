using Kada.Application.DTOs;
using MediatR;

namespace Kada.Application.Feature.Model.Query.GetModelDetails
{
    public class GetModelDetailsQuery: IRequest<ModelDTO>
    {
        public Guid Id { get; set; }
    }
}
