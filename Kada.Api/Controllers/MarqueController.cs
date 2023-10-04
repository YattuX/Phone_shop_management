using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using Kada.Application.Feature.Marque.Command.CreateMarque;
using Kada.Application.Feature.Marque.Command.DeleteMarque;
using Kada.Application.Feature.Marque.Command.UpdateMarque;
using Kada.Application.Feature.Marque.Query.GetMarque;
using Kada.Application.Feature.Marque.Query.GetMarqueDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kada.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MarqueController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MarqueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<SearchResult<MarqueDTO>> GetMarqueListPage([FromBody] SearchDTO search)
        {
            try
            {
                var types = await _mediator.Send(new GetMarqueQuery() { Search = search });
                return types;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<MarqueDTO> GetMarque(Guid id)
        {
            try
            {
                var type = await _mediator.Send(new GetMarqueDetailsQuery() { Id = id });
                return type;
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
        public async Task<ActionResult> CreateMarque([FromBody] CreateMarqueCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return CreatedAtAction(nameof(CreateMarque), new { id = response });
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
        public async Task<ActionResult> UpdateMarque(UpdateMarqueCommand request)
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
        public async Task<ActionResult> DeleteMarque(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteMarqueCommand() { Id = id });
                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
