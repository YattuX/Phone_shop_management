using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.DTOs.Search
{
    public class SearchDTO
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public Dictionary<string, string> Filters { get; set; }
    }
}
