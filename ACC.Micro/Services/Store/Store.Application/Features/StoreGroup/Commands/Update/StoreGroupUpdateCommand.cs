using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Features.StoreGroup.Commands.Update
{
    public class StoreGroupUpdateCommand:IRequest<bool>
    {
        public int Id { get; set; }
        public string StoreGroupName { get; set; }
        public string StoreGroupCode { get; set; }
    }
}
