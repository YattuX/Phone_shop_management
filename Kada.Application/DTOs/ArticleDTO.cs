using Kada.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.DTOs
{
    public class ArticleDTO
    {
        public Guid Id { get; set; }
        public Guid? StockageId { get; set; }
        public string? StockageName { get; set; }
        public Guid? CouleurId { get; set; }
        public string? CouleurName { get; set; }
        public int? NombreDeSim { get; set; }
        public string? Imei { get; set; }
        public Guid? ParticulariteId { get; set; }
        public string? ParticulariteContent { get; set; }
        public Guid? EtatId { get; set; }
        public string? EtatContent { get; set; }
        public string? Processeurs { get; set; }
        public string? TailleEcran { get; set; }
        public string? Ram { get; set; }
        public string? Qualite { get; set; }
        public string? Position { get; set; }
        public string? Description { get; set; }
        public Guid? TypeId { get; set; }
        public string? TypeContent { get; set; }
        public string? Capacite { get; set; }
        public string? Caracteristic { get; set; }
        public Guid? CaracteristiqueId { get; set; }
        public string? Puissance { get; set; }
        public string modele { get; set; }
    }
}
