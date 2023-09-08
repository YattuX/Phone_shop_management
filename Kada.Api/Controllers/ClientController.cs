using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using Kada.Application.Feature.Client_.Command.CreateClient;
using Kada.Application.Feature.Client_.Command.DeleteClient;
using Kada.Application.Feature.Client_.Command.UpdateClient;
using Kada.Application.Feature.Client_.Query.GetClientDetails;
using Kada.Application.Feature.Client_.Query.GetClients;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Kada.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IMediator _mediator;
        public ClientController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        // GET: api/<ClientController>
        [HttpPost]
        public async Task<SearchResult<ClientDto>> GetClientListPage([FromBody] SearchDTO search_)
        {
            try
            {
                var clients = await _mediator.Send(new GetClientsQuery() { Search = search_ });
                return clients;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<ClientController>/5
  /*      [HttpGet("{id}")]
        public async Task<ClientDto> GetClient(Guid id)
        {
            try
            {
                var client = await _mediator.Send(new GetClientDetailsQuery() { Id = id });
                return client;
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/<ClientController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CreateClient([FromBody] CreateClientCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return CreatedAtAction(nameof(CreateClient), new { id = response });
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateClient(UpdateClientCommand request)
        {
            await _mediator.Send(request);
            return NoContent();
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteClient(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteClientCommand() { Id = id });
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }*/
    }
}
