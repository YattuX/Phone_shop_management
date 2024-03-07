using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.DTOs
{
    public class StateStockDTO
    {
        public Guid Id { get; set; }
        public string ArticleName { get; set; }
        public double QuantiteRestante {  get; set; }
    }
}
