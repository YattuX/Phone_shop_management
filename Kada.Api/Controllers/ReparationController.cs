using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using Kada.Application.Feature.Reparation.Command.CreateReparation;
using Kada.Application.Feature.Reparation.Command.DeleteReparation;
using Kada.Application.Feature.Reparation.Command.UpdateEtatReparation;
using Kada.Application.Feature.Reparation.Command.UpdateReparation;
using Kada.Application.Feature.Reparation.Query.GetReparation;
using Kada.Application.Feature.Reparation.Query.GetReparationDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kada.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReparationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReparationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<SearchResult<ReparationDTO>> GetReparationListPage([FromBody] SearchDTO search)
        {
            try
            {
                var typeArticles = await _mediator.Send(new GetReparationQuery() { Search = search });
                return typeArticles;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ReparationDTO> GetReparation(Guid id)
        {
            try
            {
                var typeArticle = await _mediator.Send(new GetReparationDetailsQuery() { Id = id });
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
        public async Task<ActionResult> CreateReparation([FromBody] CreateReparationCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return CreatedAtAction(nameof(CreateReparation), new { id = response });
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
        public async Task<ActionResult> UpdateReparation(UpdateReparationCommand request)
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateEtatReparation(UpdateEtatReparationCommand request)
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
        public async Task<ActionResult> DeleteReparation(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteReparationCommand() { Id = id });
                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
