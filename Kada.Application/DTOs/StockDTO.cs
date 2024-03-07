using Kada.Domain;
using Kada.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.DTOs
{
    public class StockDTO
    {
        public Guid Id { get; set; }
        public double Quantite { get; set; }
        public string TypeName { get; set; }
        public string StatusName { get; set; }
        public string ArticleName { get; set; }
        public TypeStockage Type { get; set; }
        public Guid ArticleId { get; set; }
        public ArticleDTO Article { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
