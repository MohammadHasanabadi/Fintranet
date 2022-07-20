using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Features.StoreGroup.Commands.Create;
using Store.Application.Features.StoreGroup.Commands.Delete;
using Store.Application.Features.StoreGroup.Commands.Update;
using Store.Application.Features.StoreGroup.Queries;
using System.Net;

namespace Micro.Services.Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreGroupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoreGroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<StoreGroupDTO>), (int)HttpStatusCode.OK)]
        [Route("GetAllGroup")]
        public async Task<ActionResult> GetAllGroup()
        {
            //var query = new StoreGroupListQuery();
            var result = await _mediator.Send(new StoreGroupListQuery());
            return Ok(result);

        }


        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [Route("CreateGroup")]
        public async Task<ActionResult> CreateGroup(StoreGroupCreateCommand parameter)
        {
           var result= await _mediator.Send(parameter);
            return Ok(result);

        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [Route("UpdateGroup")]
        public async Task<ActionResult> UpdateGroup(StoreGroupUpdateCommand parameter)
        {
            var result = await _mediator.Send(parameter);
            return Ok(result);

        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [Route("DeleteGroup")]
        public async Task<ActionResult> DeleteGroup(StoreGroupDeleteCommand parameter)
        {
            var result = await _mediator.Send(parameter);
            return Ok(result);

        }
    }
}
