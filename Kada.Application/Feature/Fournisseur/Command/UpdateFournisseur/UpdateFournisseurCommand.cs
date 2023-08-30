using MediatR;

namespace Kada.Application.Feature.Fournisseur.Command.UpdateFournisseur
{
    public class UpdateFournisseurCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string WhatsappNumber { get; set; }
    }
}
