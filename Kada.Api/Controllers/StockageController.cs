using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using Kada.Application.Feature.Stockage.Command.CreateStockage;
using Kada.Application.Feature.Stockage.Command.DeleteStockage;
using Kada.Application.Feature.Stockage.Command.UpdateStockage;
using Kada.Application.Feature.Stockage.Query.GetStockage;
using Kada.Application.Feature.Stockage.Query.GetStockageDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kada.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StockageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<SearchResult<StockageDTO>> GetStockageListPage([FromBody] SearchDTO search)
        {
            try
            {
                var typeArticles = await _mediator.Send(new GetStockageQuery() { Search = search });
                return typeArticles;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<StockageDTO> GetStockage(Guid id)
        {
            try
            {
                var typeArticle = await _mediator.Send(new GetStockageDetailsQuery() { Id = id });
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
        public async Task<ActionResult> CreateStockage([FromBody] CreateStockageCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return CreatedAtAction(nameof(CreateStockage), new { id = response });
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
        public async Task<ActionResult> UpdateStockage(UpdateStockageCommand request)
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
        public async Task<ActionResult> DeleteStockage(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteStockageCommand() { Id = id });
                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
