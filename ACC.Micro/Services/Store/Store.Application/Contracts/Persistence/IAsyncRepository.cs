using Store.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        public  Task<IEnumerable<T>> GetAllStoreGroups();
        public  Task<T> Create(T entity);
        public  Task<T> Delete(T entity);
        public  Task<T> Update(T entity);
    }
}
