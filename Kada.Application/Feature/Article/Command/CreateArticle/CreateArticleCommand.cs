using MediatR;

namespace Kada.Application.Feature.Article.Command.CreateArticle
{
    public class CreateArticleCommand : IRequest<Guid>
    {
        public Guid? StockageId { get; set; }
        public Guid? CouleurId { get; set; }
        public int? NombreDeSim { get; set; }
        public string? Imei { get; set; }
        public Guid? ParticulariteId { get; set; }
        public Guid? EtatId { get; set; }
        public string? Processeurs { get; set; }
        public string? TailleEcran { get; set; }
        public string? Ram { get; set; }
        public string? Qualite { get; set; }
        public string? Position { get; set; }
        public Guid? TypeId { get; set; }
        public string? Capacite { get; set; }
        public Guid CaracteristiqueId { get; set; }
        public string? Puissance { get; set; }
        public string? Camera { get; set; }
    }
}
