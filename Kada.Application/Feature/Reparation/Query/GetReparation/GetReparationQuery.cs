using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Reparation.Query.GetReparation
{
    public class GetReparationQuery : IRequest<SearchResult<ReparationDTO>>
    {
        public SearchDTO Search { get; set; }
    }
}
