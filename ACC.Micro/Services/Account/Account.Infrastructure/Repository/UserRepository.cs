using Account.Application.Contracts;
using Account.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.Infrastructure.Repository
{
    public class UserRepository : IUserRepository<User>
    {
        private readonly IAccountContextDb _context;

        public UserRepository(IAccountContextDb iAccountContextDb)
        {
            _context = iAccountContextDb;
        }

        public async Task<User> Create(User entity)
        {
            await _context.Users.InsertOneAsync(entity);
            return entity;
        }

        public async Task<bool> Delete(User entity)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(x => x.Id, entity.UserName);

            DeleteResult resut = await _context.Users.DeleteOneAsync(filter);
            return resut.IsAcknowledged && resut.DeletedCount > 0;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _context.Users.Find(x => true).ToListAsync();

        }

        public async Task<User> Update(User entity)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq(x => x.Id, entity.Id);

           ReplaceOneResult result= await _context.Users.ReplaceOneAsync(filter, entity);

            //result.IsAcknowledged && result.ModifiedCount > 0;
            return entity;
        }
    }
}
