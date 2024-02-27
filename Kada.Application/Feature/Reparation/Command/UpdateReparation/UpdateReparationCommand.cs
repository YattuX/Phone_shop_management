using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Reparation.Command.UpdateReparation
{
    public class UpdateReparationCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid ArticleId { get; set; }
        public string DescriptionProbleme { get; set; }
        public DateTime DateDepot { get; set; }
        public DateTime? DateLivraison { get; set; }
        public decimal CoutReparation { get; set; }
        public string ReparateurEnCharge { get; set; }
        public string Remarques { get; set; }
    }
}
