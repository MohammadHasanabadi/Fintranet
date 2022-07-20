using ACC.Bus.Common.Events;
using Account.Application.Features;
using Account.Domain.Entities;
using AutoMapper;
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
        private readonly IPublisher _publisher;
        private readonly IMapper _mapper;


        public UserController(IMediator mediat, IPublisher publisher, IMapper mapper)
        {
            _mediator = mediat;
            _publisher = publisher;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<bool> CreateUser(CreateUserCommand param)
        {
            await _mediator.Send(param);

            var eventData = _mapper.Map<UserCreateEvent>(param);
            await _publisher.Publish(eventData);

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
