using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.DTOs
{
    public class FournisseurDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string WhatsappNumber { get; set; }
        public string Identifiant { get; set; }
    }
}
