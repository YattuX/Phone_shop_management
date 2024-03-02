using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Reparation.Command.CreateReparation
{
    public class CreateReparationCommand : IRequest<Guid>
    {
        public Guid ClientId { get; set; }
        public Guid ArticleId { get; set; }
        public string DescriptionProbleme { get; set; }
        public DateTime DateDepot { get; set; }
        public DateTime? DateLivraison { get; set; }
        public decimal CoutReparation { get; set; }
        public string ReparateurEnCharge { get; set; }
        public string? Remarques { get; set; }
    }
}
