using Kada.Application.DTOs;
using MediatR;

namespace Kada.Application.Feature.Marque.Query.GetMarqueDetails
{
    public class GetMarqueDetailsQuery: IRequest<MarqueDTO>
    {
        public Guid Id { get; set; }
    }
}
