using Kada.Domain;

namespace Kada.Application.DTOs
{
    public class MarqueDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string TypeArticleName { get; set; }
        public Guid TypeArticleId { get; set; }
    }
}
