using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.DTOs
{
    public class ClientDto
    {
        public string Identifiant { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string WhatsappNumber { get; set; }
        public string Adress { get; set; }
        public bool IsClientEnGros { get; set; }
    }
}
