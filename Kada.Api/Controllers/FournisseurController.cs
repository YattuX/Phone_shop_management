using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using Kada.Application.Feature.Client_.Query.GetClients;
using Kada.Application.Feature.Fournisseur.Command.CreateFournisseur;
using Kada.Application.Feature.Fournisseur.Command.DeleteFournisseur;
using Kada.Application.Feature.Fournisseur.Command.UpdateFournisseur;
using Kada.Application.Feature.Fournisseur.Query.GetFournisseur;
using Kada.Application.Feature.Fournisseur.Query.GetFournisseurDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Kada.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FournisseurController : ControllerBase
    {
        private IMediator _mediator;
        public FournisseurController(IMediator mediator) 
        {
            _mediator = mediator;
        }
        // GET: api/<FournisseurController>
       [HttpPost]
        public async Task<SearchResult<FournisseurDto>> GetFournisseurListPage([FromBody] SearchDTO search)
        {
            try
            {
                var Fournisseurs = await _mediator.Send(new GetFournisseurQuery() { Search = search });
                return Fournisseurs;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<FournisseurController>/5
        [HttpGet("{id}")]
        public async Task<FournisseurDto> GetFournisseur(Guid id)
        {
            try
            {
                var fournisseur = await _mediator.Send(new GetFournisseurDetailsQuery() { Id = id });
                return fournisseur;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/<FournisseurController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateFournisseur([FromBody] CreateFournisseurCommand request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(nameof(CreateFournisseur), new { id = response });
        }

        // PUT api/<FournisseurController>/5
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateFournisseur(UpdateFournisseurCommand request)
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

        // DELETE api/<FournisseurController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteFournisseur(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteFournisseurCommand() { Id = id });
                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
