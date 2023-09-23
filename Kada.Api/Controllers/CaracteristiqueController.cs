using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using Kada.Application.Feature.Caracteristique.Command.CreateCaracteristique;
using Kada.Application.Feature.Caracteristique.Command.DeleteCaracteristique;
using Kada.Application.Feature.Caracteristique.Command.UpdateCaracteristique;
using Kada.Application.Feature.Caracteristique.Query.GetCaracteristique;
using Kada.Application.Feature.Caracteristique.Query.GetCaracteristiqueDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kada.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CaracteristiqueController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CaracteristiqueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<SearchResult<CaracteristiqueDTO>> GetCaracteristiqueListPage([FromBody] SearchDTO search)
        {
            try
            {
                var types = await _mediator.Send(new GetCaracteristiqueQuery() { Search = search });
                return types;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<CaracteristiqueDTO> GetCaracteristique(Guid id)
        {
            try
            {
                var type = await _mediator.Send(new GetCaracteristiqueDetailsQuery() { Id = id });
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
        public async Task<ActionResult> CreateCaracteristique([FromBody] CreateCaracteristiqueCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return CreatedAtAction(nameof(CreateCaracteristique), new { id = response });
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
        public async Task<ActionResult> UpdateCaracteristique(UpdateCaracteristiqueCommand request)
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
        public async Task<ActionResult> DeleteCaracteristique(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteCaracteristiqueCommand() { Id = id });
                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
