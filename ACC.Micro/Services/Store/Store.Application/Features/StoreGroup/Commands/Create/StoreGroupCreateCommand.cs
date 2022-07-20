using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.StoreGroup.Commands.Create
{
    public class StoreGroupCreateCommand:IRequest<int>
    {
        public string StoreGroupName { get; set; }
        public string StoreGroupCode { get; set; }
    }
}
