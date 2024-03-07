using Kada.Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Stock.Command.UpdateStock
{
    public class UpdateStockCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public double Quantite { get; set; }
        public TypeStockage Type { get; set; }
        public Guid ArticleId { get; set; }
    }
}
