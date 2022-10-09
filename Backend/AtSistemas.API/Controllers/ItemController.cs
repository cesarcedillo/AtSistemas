using AtSistemas.Identity.Models;
using AtSistemas.Application.Features.Items.Commands.CreateItem;
using AtSistemas.Application.Features.Items.Commands.DeleteItem;
using AtSistemas.Application.Features.Items.Commands.UpdateItem;
using AtSistemas.Application.Features.Items.Queries;
using AtSistemas.Application.Features.Items.Queries.GetItemById;
using AtSistemas.Application.Features.Items.Queries.GetItemsList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AtSistemas.Identity.Authorization;


namespace AtSistemas.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize]
        [HttpGet("{id}", Name = "GetItembyId")]
        [ProducesResponseType(typeof(ItemsVm), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ItemsVm>> GetItembyId(string id)
        {
            var query = new GetItemByIdQuery(id);
            var item = await _mediator.Send(query);
            return Ok(item);
        }

        [Authorize]
        [HttpGet(Name = "GetItem")]
        [ProducesResponseType(typeof(IEnumerable<ItemsVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ItemsVm>>> GetItems()
        {
            var query = new GetItemsListQuery();
            var itemsList = await _mediator.Send(query);
            return Ok(itemsList);
        }

        [Authorize(Role.Admin)]
        [HttpPost(Name = "CreateItem")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<string>> CreateItem([FromBody] CreateItemCommand command)
        {
            return await _mediator.Send(command);
        }

        [Authorize(Role.Admin)]
        [HttpPut(Name = "UpdateItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateItem([FromBody] UpdateItemCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [Authorize(Role.Admin)]
        [HttpDelete("{id}", Name = "DeleteItem")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteItem(string id)
        {
            var command = new DeleteItemCommand { Id = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
