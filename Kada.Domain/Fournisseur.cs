using Kada.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Domain
{
    public class Fournisseur : BaseEntity
    {
        public string Identifiant { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email {get; set; }
        public string WhatsappNumber { get; set; }
    }
}
