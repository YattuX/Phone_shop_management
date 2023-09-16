using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using Kada.Application.Feature.TypeArticle.Command.CreateTypeArticle;
using Kada.Application.Feature.TypeArticle.Command.DeleteTypeArticle;
using Kada.Application.Feature.TypeArticle.Command.UpdateTypeArticle;
using Kada.Application.Feature.TypeArticle.Query.GetTypeArticle;
using Kada.Application.Feature.TypeArticle.Query.GetTypeArticleDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kada.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TypeArticleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TypeArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<SearchResult<TypeArticleDTO>> GetTypeArticleListPage([FromBody] SearchDTO search)
        {
            try
            {
                var typeArticles = await _mediator.Send(new GetTypeArticleQuery() { Search = search });
                return typeArticles;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<TypeArticleDTO> GetTypeArticle(Guid id)
        {
            try
            {
                var typeArticle = await _mediator.Send(new GetTypeArticleDetailsQuery() { Id = id });
                return typeArticle;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateTypeArticle([FromBody] CreateTypeArticleCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return CreatedAtAction(nameof(CreateTypeArticle), new { id = response });
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateTypeArticle(UpdateTypeArticleCommand request)
        {
            try
            {
                await _mediator.Send(request);
                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteTypeArticle(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteTypeArticleCommand() { Id = id });
                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
