using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Application.Contracts
{
    public interface IUserRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();

        public Task<T> Create(T entity);

        public Task<T> Update(T entity);

        public Task<bool> Delete(T entity);

    }
}
