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
        public Guid StockageId { get; set; }
        public Stockage Stockage { get; set; }
        public Guid CouleurId { get; set; }
        public Couleur Couleur { get; set; }
        public bool NombreDeSim { get; set; }
        public bool Imei { get; set; }
        public Guid ParticulariteId { get; set; }
        public Particularite Particularite { get; set; }
        public Guid EtatId { get; set; }
        public Etat Etat { get; set; }
        public string Processeurs { get; set; }
        public string TailleEcran { get; set; }
        public string Ram { get; set; }
        public string Nom { get; set; }
        public string Qualite { get; set; }
        public string Position { get; set; }
        public Guid TypeId { get; set; }
        public Type_ Type { get; set; }
        public string Capacite { get; set; }
        public string Caracteristique { get; set; }
        public string Puissance { get; set; }
    }
}
