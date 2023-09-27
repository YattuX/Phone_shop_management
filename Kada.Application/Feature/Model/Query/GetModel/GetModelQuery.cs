using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using MediatR;

namespace Kada.Application.Feature.Model.Query.GetModel
{
    public class GetModelQuery : IRequest<SearchResult<ModelDTO>>
    {
        public SearchDTO Search { get; set; }
    }
}
