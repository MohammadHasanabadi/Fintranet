using MassTransit;
using Micro.Services.ACC.DTOs;
using Micro.Services.ACC.Services;
using Microsoft.AspNetCore.Mvc;

namespace Micro.Services.ACC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly IPublishEndpoint _endpoint;



        //private readonly ILogger<GroupController> _logger;

        public GroupController(/*ILogger<GroupController> logger*/
            IGroupService groupService,
            IPublishEndpoint endpoint
            )
        {
            _groupService = groupService;
            _endpoint = endpoint;
            //_logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _groupService.GetAllGroups();


            return Ok(result);


        }

        [HttpPost]
        public async Task<ActionResult> CreateGroup(GroupDTO groupDTO)
        {

            var result = await _groupService.CreateGroup(groupDTO);


            return Ok(groupDTO);


        }
    }
}