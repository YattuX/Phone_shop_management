using Kada.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Domain
{
    public class Marque : BaseEntity
    {
        public string Name { get; set; }
        public Guid TypeArticleId { get; set; }
        public TypeArticle TypeArticle { get; set;}
    }
}
