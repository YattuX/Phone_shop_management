using Kada.Domain.Common;


namespace Kada.Domain
{
    public class Client : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string WhatsappNumber { get; set; }
        public string Adress { get; set; }
        public bool IsClientEnGros { get; set; }
    }
}
