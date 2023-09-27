using Kada.Application.DTOs;
using MediatR;

namespace Kada.Application.Feature.Caracteristique.Query.GetCaracteristiqueDetails
{
    public class GetCaracteristiqueDetailsQuery: IRequest<CaracteristiqueDTO>
    {
        public Guid Id { get; set; }
    }
}
