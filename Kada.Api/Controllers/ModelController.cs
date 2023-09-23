using Kada.Application.DTOs;
using Kada.Application.DTOs.Search;
using Kada.Application.Feature.Model.Command.CreateModel;
using Kada.Application.Feature.Model.Command.DeleteModel;
using Kada.Application.Feature.Model.Command.UpdateModel;
using Kada.Application.Feature.Model.Query.GetModel;
using Kada.Application.Feature.Model.Query.GetModelDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Kada.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ModelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<SearchResult<ModelDTO>> GetModelListPage([FromBody] SearchDTO search)
        {
            try
            {
                var types = await _mediator.Send(new GetModelQuery() { Search = search });
                return types;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ModelDTO> GetModel(Guid id)
        {
            try
            {
                var type = await _mediator.Send(new GetModelDetailsQuery() { Id = id });
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
        public async Task<ActionResult> CreateModel([FromBody] CreateModelCommand request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return CreatedAtAction(nameof(CreateModel), new { id = response });
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
        public async Task<ActionResult> UpdateModel(UpdateModelCommand request)
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
        public async Task<ActionResult> DeleteModel(Guid id)
        {
            try
            {
                await _mediator.Send(new DeleteModelCommand() { Id = id });
                return NoContent();

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
