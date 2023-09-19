using Kada.Application.DTOs;
using MediatR;

namespace Kada.Application.Feature.Particularite.Query.GetParticulariteDetails
{
    public class GetParticulariteDetailsQuery: IRequest<ParticulariteDTO>
    {
        public Guid Id { get; set; }
    }
}
