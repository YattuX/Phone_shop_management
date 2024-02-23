using Kada.Domain.Common;
using Kada.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Domain
{
    public class Stock : BaseEntity
    {
        public double Quantite { get; set; }
        public TypeStockage Type {  get; set; }
        public Guid ArticleId { get; set; }
        public Article Article { get; set; }

    }
}
