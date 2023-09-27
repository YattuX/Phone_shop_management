using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using Kada.Application.Feature.Etat.Command.CreateEtat;
using Kada.Application.Feature.Etat.Command.DeleteEtat;
using Kada.Application.Feature.Etat.Command.UpdateEtat;
using Kada.Application.Feature.Etat.Query.GetEtat;
using Kada.Application.Feature.Etat.Query.GetEtatDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kada.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EtatController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EtatController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<SearchResult<EtatDTO>> GetEtatListPage([FromBody] SearchDTO search)
        {
            try
            {
                var types = await _mediator.Send(new GetEtatQuery() { Search = search });
                return types;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<EtatDTO> GetEtat(Guid id)
        {
            try
            {
                var type = await _mediator.Send(new GetEtatDetailsQuery() { Id = id });
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
        public async Task<ActionResult> CreateEtat([FromBody] CreateEtatCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return CreatedAtAction(nameof(CreateEtat), new { id = response });
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
        public async Task<ActionResult> UpdateEtat(UpdateEtatCommand request)
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
        public async Task<ActionResult> DeleteEtat(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteEtatCommand() { Id = id });
                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
