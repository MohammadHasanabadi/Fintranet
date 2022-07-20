using Store.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entities
{
    public class StoreGroup:BaseEntity
    {
        public string? StoreGroupName { get; set; }
        public string? StoreGroupCode { get; set; }
    }
}
