using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.Fournisseur.Query.GetFournisseur
{
    public class GetFournisseurQuery : IRequest<SearchResult<FournisseurDto>>
    {
        public SearchDTO Search { get; set; }
    }
}
