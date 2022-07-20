using Account.Application.Contracts;
using Account.Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Features
{
    public class CreateUserHandlerCommand : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserRepository<User> _IUserRepository;
        private readonly IMapper _mapper;

        public CreateUserHandlerCommand(IUserRepository<User> rep, IMapper mapper)
        {
            _IUserRepository = rep;
            _mapper = mapper;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var parameter = _mapper.Map<User>(request);
            await _IUserRepository.Create(parameter);
            return true;
        }
    }
}
