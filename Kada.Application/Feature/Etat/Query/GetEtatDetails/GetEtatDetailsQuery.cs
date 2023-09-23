using Kada.Application.DTOs;
using MediatR;

namespace Kada.Application.Feature.Etat.Query.GetEtatDetails
{
    public class GetEtatDetailsQuery: IRequest<EtatDTO>
    {
        public Guid Id { get; set; }
    }
}
