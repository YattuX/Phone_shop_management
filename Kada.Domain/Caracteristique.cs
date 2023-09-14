using Kada.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Domain
{
    public class Caracteristique : BaseEntity
    {
        public bool Marque { get; set; }
        public bool Modele { get; set; }
        public bool Stockage { get; set; }
        public bool Couleur { get; set; }
        public bool NombreDeSim { get; set; }
        public bool Imei { get; set; }
        public bool Particularite { get; set; }
        public bool Etat { get; set; }
        public bool Processeurs { get; set; }
        public bool TailleEcran { get; set; }
        public bool Ram { get; set; }
        public bool Nom { get; set; }
        public bool Qualite { get; set; }
        public bool Position { get; set; }
        public bool Type { get; set; }
        public bool Capacite { get; set; }
        public bool Caracteristic{ get; set; }
        public bool Puissance { get; set; }
        public Guid ModelId { get; set; }
        public Model? Model { get; set; }
    }
}
