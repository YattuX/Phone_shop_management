using MediatR;

namespace Kada.Application.Feature.Client_.Command.CreateClient
{
    public class CreateClientCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string WhatsappNumber { get; set; }
        public string Adress { get; set; }
        public bool IsClientEnGros { get; set; }
    }
}
