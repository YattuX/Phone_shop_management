using Kada.Application.DTOs.Search;
using Kada.Application.DTOs;
using Kada.Application.Feature.Stockage.Command.CreateStockage;
using Kada.Application.Feature.Stockage.Command.DeleteStockage;
using Kada.Application.Feature.Stockage.Command.UpdateStockage;
using Kada.Application.Feature.Stockage.Query.GetStockage;
using Kada.Application.Feature.Stockage.Query.GetStockageDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Kada.Application.Feature.Stock.Command.AddStock;
using Kada.Application.Feature.Stock.Query.GetStock;
using Kada.Application.Feature.Stock.Command.UpdateStock;
using Kada.Application.Feature.Stock.Query.GetStatStock;

namespace Kada.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StockController(IMediator mediator)
        {

            _mediator = mediator;   

        }

        [HttpPost]
        public async Task<SearchResult<StockDTO>> GetStockListPage([FromBody] SearchDTO search)
        {
            try
            {
                var stocks = await _mediator.Send(new GetStockQuery() { Search = search });
                return stocks;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<SearchResult<StateStockDTO>> GetStateStockListPage([FromBody] SearchDTO search)
        {
            try
            {
                var stateStocks = await _mediator.Send(new GetStatStockQuery() { Search = search });
                return stateStocks;
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
        public async Task<ActionResult> AddStock([FromBody] AddStockCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return CreatedAtAction(nameof(AddStock), new { id = response });
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
        public async Task<ActionResult> UpdateStock(UpdateStockCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
