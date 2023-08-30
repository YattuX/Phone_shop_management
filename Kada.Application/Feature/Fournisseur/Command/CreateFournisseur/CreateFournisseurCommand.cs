using MediatR;

namespace Kada.Application.Feature.Fournisseur.Command.CreateFournisseur
{
    public class CreateFournisseurCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string WhatsappNumber { get; set; }
    }
}
