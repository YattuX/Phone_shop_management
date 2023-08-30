using Kada.Application.DTOs;
using MediatR;

namespace Kada.Application.Feature.Fournisseur.Query.GetFournisseurDetails
{
    public class GetFournisseurDetailsQuery : IRequest<FournisseurDto>
    {
        public Guid Id { get; set; }
    }
}
