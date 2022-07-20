using Store.Application.Features.StoreGroup.Queries;
using Store.Domain.Common;
using Store.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Contracts.Persistence
{
    public interface IStoreGroupRepository 
    {
        public Task<IEnumerable<StoreGroup>> GetAllStoreGroups();
        public Task<StoreGroup> Create(StoreGroup entity);
        public Task<StoreGroup> Delete(StoreGroup entity);
        public Task<StoreGroup> Update(StoreGroup entity);
    }
}
