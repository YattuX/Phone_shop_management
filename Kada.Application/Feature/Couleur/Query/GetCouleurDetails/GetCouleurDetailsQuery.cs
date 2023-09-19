using Kada.Application.DTOs;
using MediatR;

namespace Kada.Application.Feature.Couleur.Query.GetCouleurDetails
{
    public class GetCouleurDetailsQuery: IRequest<CouleurDTO>
    {
        public Guid Id { get; set; }
    }
}
