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
    }
}
