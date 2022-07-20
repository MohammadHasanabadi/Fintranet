using Account.Application.Contracts;
using Account.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Features
{
    public class GetAllUsersHandlerQuery : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
    {
        private readonly IUserRepository<User> _IUserRepository;

        public GetAllUsersHandlerQuery(IUserRepository<User> iUserRepository)
        {
            _IUserRepository = iUserRepository;
        }

        public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _IUserRepository.GetAll();
        }
    }
}
