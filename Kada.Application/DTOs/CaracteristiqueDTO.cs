﻿namespace Kada.Application.DTOs
{
    public class CaracteristiqueDTO
    {
        public Guid Id { get; set; }
        public bool HasStockage { get; set; }
        public bool HasCouleur { get; set; }
        public bool HasNombreDeSim { get; set; }
        public bool HasImei { get; set; }
        public bool HasParticularite { get; set; }
        public bool HasEtat { get; set; }
        public bool HasProcesseurs { get; set; }
        public bool HasTailleEcran { get; set; }
        public bool HasRam { get; set; }
        public bool HasQualite { get; set; }
        public bool HasType { get; set; }
        public bool HasCapacite { get; set; }
        public bool HasPuissance { get; set; }
        public bool HasPosition { get; set; }
        public bool HasDescription { get; set; }
        public Guid ModelId { get; set; }
        public string? ModelName { get; set; }
    }
}
