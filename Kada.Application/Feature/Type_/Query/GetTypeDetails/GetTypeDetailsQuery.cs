using Kada.Application.DTOs;
using MediatR;

namespace Kada.Application.Feature.Type_.Query.GetTypeDetails
{
    public class GetTypeDetailsQuery: IRequest<TypeDTO>
    {
        public Guid Id { get; set; }
    }
}
