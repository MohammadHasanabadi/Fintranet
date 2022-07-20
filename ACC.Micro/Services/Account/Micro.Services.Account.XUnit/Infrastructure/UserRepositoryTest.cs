using Account.Application.Contracts;
using Account.Domain.Entities;
using Account.Infrastructure.Repository;
using Moq;
using Account.Application.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Micro.Services.Account.XUnit.Infrastructure
{
    public class UserRepositoryTest
    {
        private Mock<IUserRepository<User>> Irepo;
        private UserRepository _rep;
        private Mock<IAccountContextDb> contextdb;

        public UserRepositoryTest()
        {
            Irepo = new Mock<IUserRepository<User>>();
            contextdb = new Mock<IAccountContextDb>();
            _rep = new UserRepository(contextdb.Object);
        }


        [Fact]
        public async Task UpdateUser()
        {
            var entities = SampleEntities();
            var entity = new User
            {
                Id = "123",
                Name = "mohammad"
            };

            FilterDefinition<User> filter = null;
            contextdb.Setup(o => o.Users.FindOneAndReplaceAsync(It.IsAny<FilterDefinition<User>>(), entity, It.IsAny<FindOneAndReplaceOptions<User, User>>(), default(CancellationToken)))
                //.Callback<FilterDefinition<User>, User, FindOneAndReplaceOptions<User, User>, CancellationToken>((f, e, o, c) => filter = f)
                .ReturnsAsync(entity);

            var target = new UserRepository(contextdb.Object);

            await target.Update(entity);

            contextdb.Verify(o => o.Users.FindOneAndReplaceAsync(It.IsAny<ExpressionFilterDefinition<User>>(), entity, It.IsAny<FindOneAndReplaceOptions<User, User>>(), default(CancellationToken)));
            Assert.NotNull(filter);
            Assert.IsType<ExpressionFilterDefinition<User>>(filter);
            var expressionFilter = (ExpressionFilterDefinition<User>)filter;
            var replacedEntities = entities.AsQueryable().Where(expressionFilter.Expression);
            var expectedEntities = new User[] { entities[1] };
            Assert.Equal(expectedEntities, replacedEntities);
        }


     
        private static List<User> SampleEntities()
        {
            return new List<User>
            {
                new User
                {
                    Id = "user",
                    Name = "John"
                },
                new User
                {
                    Id = "user1",
                    Name = "Bob"
                },
                new User
                {
                    Id = "user2",
                },
                new User
                {
                    Id = "user10",
                    Name = "John"
                }
            };
        }
    }
}
