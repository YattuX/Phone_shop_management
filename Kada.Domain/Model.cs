
using Kada.Domain.Common;

namespace Kada.Domain
{
    public class Model : BaseEntity
    {
        public string Name { get; set; }
        public Guid MarqueId { get; set; }
        public Marque Marque { get; set; }
    }
}
