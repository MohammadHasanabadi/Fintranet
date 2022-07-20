using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.StoreGroup.Commands.Delete
{
    public class StoreGroupDeleteCommand:IRequest<bool>
    {
        public int Id { get; set; }
    }
}
