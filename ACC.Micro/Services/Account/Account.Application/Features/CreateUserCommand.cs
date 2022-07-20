using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Features
{
    public class CreateUserCommand:IRequest<bool>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? Familly { get; set; }
        public string? Mob { get; set; }
    }
}
