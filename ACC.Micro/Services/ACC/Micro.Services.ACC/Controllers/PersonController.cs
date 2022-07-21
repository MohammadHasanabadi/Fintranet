using GrpcService;
using Micro.Services.ACC.GrpcServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Micro.Services.ACC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly GreatGrpcService _GreatGrpcService;
        public PersonController(GreatGrpcService GreatGrpcService)
        {
            _GreatGrpcService = GreatGrpcService;
        }

        [HttpGet]
        [Route("GetAllPerson")]
        public async Task<HelloArrayReply> GetAllPerson()
        {
            return await _GreatGrpcService.SayHello("Hello");
        }
    }
}
