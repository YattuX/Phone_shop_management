using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using Kada.Application.Feature.Particularite.Command.CreateParticularite;
using Kada.Application.Feature.Particularite.Command.DeleteParticularite;
using Kada.Application.Feature.Particularite.Command.UpdateParticularite;
using Kada.Application.Feature.Particularite.Query.GetParticularite;
using Kada.Application.Feature.Particularite.Query.GetParticulariteDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kada.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ParticulariteController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ParticulariteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<SearchResult<ParticulariteDTO>> GetParticulariteListPage([FromBody] SearchDTO search)
        {
            try
            {
                var types = await _mediator.Send(new GetParticulariteQuery() { Search = search });
                return types;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ParticulariteDTO> GetParticularite(Guid id)
        {
            try
            {
                var type = await _mediator.Send(new GetParticulariteDetailsQuery() { Id = id });
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
        public async Task<ActionResult> CreateParticularite([FromBody] CreateParticulariteCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return CreatedAtAction(nameof(CreateParticularite), new { id = response });
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
        public async Task<ActionResult> UpdateParticularite(UpdateParticulariteCommand request)
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
        public async Task<ActionResult> DeleteParticularite(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteParticulariteCommand() { Id = id });
                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
