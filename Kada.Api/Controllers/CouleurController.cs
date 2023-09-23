using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using Kada.Application.Feature.Couleur.Command.CreateCouleur;
using Kada.Application.Feature.Couleur.Command.DeleteCouleur;
using Kada.Application.Feature.Couleur.Command.UpdateCouleur;
using Kada.Application.Feature.Couleur.Query.GetCouleur;
using Kada.Application.Feature.Couleur.Query.GetCouleurDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kada.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CouleurController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CouleurController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<SearchResult<CouleurDTO>> GetCouleurListPage([FromBody] SearchDTO search)
        {
            try
            {
                var typeArticles = await _mediator.Send(new GetCouleurQuery() { Search = search });
                return typeArticles;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<CouleurDTO> GetCouleur(Guid id)
        {
            try
            {
                var typeArticle = await _mediator.Send(new GetCouleurDetailsQuery() { Id = id });
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
        public async Task<ActionResult> CreateCouleur([FromBody] CreateCouleurCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return CreatedAtAction(nameof(CreateCouleur), new { id = response });
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
        public async Task<ActionResult> UpdateCouleur(UpdateCouleurCommand request)
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
        public async Task<ActionResult> DeleteCouleur(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteCouleurCommand() { Id = id });
                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
