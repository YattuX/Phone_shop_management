using Kada.Domain.Enums;
using Kada.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.DTOs
{
    public class ReparationDTO
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public Guid ArticleId { get; set; }
        public string DescriptionProbleme { get; set; }
        public DateTime DateDepot { get; set; }
        public DateTime? DateLivraison { get; set; }
        public string EtatReparation { get; set; }
        public string StatutPaiement { get; set; }
        public decimal CoutReparation { get; set; }
        public string ReparateurEnCharge { get; set; }
        public string Remarques { get; set; }
        public string ClientName { get; set; }
        public string ArticleName { get; set; }
    }
}
