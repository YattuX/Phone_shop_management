using Kada.Domain.Common;
using Kada.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kada.Domain
{
    public class Reparation : BaseEntity
    {
        public Guid ClientId { get; set; }
        public Guid ArticleId { get; set; }
        public string DescriptionProbleme { get; set; }
        public DateTime DateDepot { get; set; }
        public DateTime? DateLivraison { get; set; }
        public EtatReparation EtatReparation { get; set; } = EtatReparation.EnAttente;
        public StatutPaiement StatutPaiement { get; set; } = StatutPaiement.Impaye;
        public decimal CoutReparation { get; set; }
        public string ReparateurEnCharge { get; set; }
        public string Remarques { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Client Client { get; set; }
        [ForeignKey(nameof(ArticleId))]
        public Article Article { get; set; }
    }
}
