using ACC.Bus.Common.Events;
using Account.Application.Features;
using Account.Domain.Entities;
using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Micro.Services.Account.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper _mapper;


        public UserController(IMediator mediat, IPublishEndpoint publisher, IMapper mapper)
        {
            _mediator = mediat;
            _publishEndpoint = publisher;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<bool> CreateUser(CreateUserCommand param)
        {

            await _mediator.Send(param);

            var eventData = _mapper.Map<UserCreateEvent>(param);


            await _publishEndpoint.Publish(eventData);


            return true;

        }

        [HttpPost]
        [Route("GetAllUsers")]
        public async Task<IEnumerable<User>> GetAllUsers(GetAllUsersQuery param)
        {
            return await _mediator.Send(param);

        }
    }
}
