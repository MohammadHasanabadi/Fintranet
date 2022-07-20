using Account.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Features
{
    public class GetAllUsersQuery:IRequest<IEnumerable<User>>
    {
    }
}
