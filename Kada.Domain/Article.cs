using Kada.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Domain
{
    public class Article : BaseEntity
    {
        public Guid? StockageId { get; set; }
        public Stockage Stockage { get; set; }
        public Guid? CouleurId { get; set; }
        public Couleur Couleur { get; set; }
        public int? NombreDeSim { get; set; }
        public string? Imei { get; set; }
        public Guid? ParticulariteId { get; set; }
        public Particularite Particularite { get; set; }
        public Guid? EtatId { get; set; }
        public Etat Etat { get; set; }
        public string? Processeurs { get; set; }
        public string? TailleEcran { get; set; }
        public string? Ram { get; set; }
        public string? Qualite { get; set; }
        public string? Position { get; set; }
        public Guid? TypeId { get; set; }
        public Type_ Type { get; set; }
        public string? Capacite { get; set; }
        public Guid CaracteristiqueId { get; set; }
        public Caracteristique Caracteristique { get; set; }
        public string? Description { get; set; }
        public string? Puissance { get; set; }
    }
}
