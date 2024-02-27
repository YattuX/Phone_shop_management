using Kada.Application.DTOs;
using MediatR;

namespace Kada.Application.Feature.Reparation.Query.GetReparationDetails
{
    public class GetReparationDetailsQuery : IRequest<ReparationDTO>
    {
        public Guid Id { get; set; }
    }
}
