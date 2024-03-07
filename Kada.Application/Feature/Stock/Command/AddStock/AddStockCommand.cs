using Kada.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Stock.Command.AddStock
{
    public class AddStockCommand : IRequest<Guid>
    {
        public double Quantite { get; set; }
        public TypeStockage Type { get; set; }
        public Guid ArticleId { get; set; }
    }
}
