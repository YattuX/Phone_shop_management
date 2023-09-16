using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kada.Application.Feature.TypeArticle.Query.GetTypeArticle
{
    public class GetTypeArticleQuery : IRequest<SearchResult<TypeArticleDTO>>
    {
        public SearchDTO Search { get; set; }
    }
}
