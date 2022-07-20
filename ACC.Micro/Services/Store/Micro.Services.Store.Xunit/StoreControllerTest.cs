using MediatR;
using Micro.Services.Store.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Store.Application.Features.StoreGroup.Queries;
using Shouldly;

namespace Micro.Services.Store.Xunit
{
    public class StoreControllerTest
    {
        Mock<IMediator> meditaor;
        StoreGroupController controller;

        public StoreControllerTest()
        {
            meditaor = new Mock<IMediator>();
            controller = new StoreGroupController(meditaor.Object);
        }

        [Fact]
        public async void GetALLGroup_Test()
        {
            //Asssert
            var groupname = new StoreGroupListQuery();

            meditaor.Setup(x => x.Send(It.IsAny<StoreGroupListQuery>(), CancellationToken.None)).
                ReturnsAsync(new List<StoreGroupDTO>()
                {
                    new StoreGroupDTO()
                    {
                        Id = 1,
                        StoreGroupCode="",
                        StoreGroupName=""
                    }
                });

            var result = (OkObjectResult)await controller.GetAllGroup();

            meditaor.Verify(service => service.Send(groupname,CancellationToken.None), Times.Once);

        }

        [Fact]
        public async void GetAllGroup_List()
        {
            var result = (OkObjectResult)await controller.GetAllGroup();

            Assert.Equal(new List<StoreGroupDTO>(), result.Value);

        }




        //    //[Fact]
        //    //public async void BookRepository_CreateNewBook_Valid_Success()
        //    //{
        //    //    //Arrange
        //    //    contextdb.Setup(op => op.Users.InsertOneAsync(It.IsAny<User>(), null,
        //    //    default(CancellationToken))).Returns(Task.CompletedTask);

        ////        _mockContext.Setup(c => c.GetCollection<Book>
        ////(typeof(Book).Name)).Returns(_mockCollection.Object);
        ////        var bookRepo = new BookRepository(_mockContext.Object);

        ////        //Act
        ////        await bookRepo.Create(_book);

        //        //Assert 

        //        //_mockCollection.Verify(c => c.InsertOneAsync(_book, null, default(CancellationToken)), Times.Once);
        //    }

        //[Fact]
        //public async void UserRepository_CreateUser()
        //{
        //    //Arange
        //    //Irepo.Setup(services => services.Create(It.IsAny<User>()))
        //    //   .Returns(Task.FromResult<User>(new User()
        //    //   {
        //    //       Id = "1",
        //    //       Familly = "hassanabadi",
        //    //       Mob = "989128303238",
        //    //       Name = "Mohammad",
        //    //       Password = "123",
        //    //   })
        //    //  );
        //    var command = new User() { Id=Guid.NewGuid().ToString(),UserName=""};
        //    var mockRepo = new Mock<IUserRepository<User>>();
        //    var mockDbContext = new Mock<IAccountContextDb>();
        //    mockDbContext.Setup(s => s.Users.InsertOneAsync(It.IsAny<User>(), It.IsAny<InsertOneOptions>(), It.IsAny<System.Threading.CancellationToken>()));


        //    //Act
        //   var result= await _rep.Create(It.IsAny<User>());


        //    //Assert
        //    //mockDbContext.Verify(s => s.Users.InsertOneAsync(It.IsAny<User>(), It.IsAny<InsertOneOptions>(), It.IsAny<System.Threading.CancellationToken>()), Times.Once);

        //}


        //[Fact]
        //public async Task should_create_user_when_command_valid()
        //{
        //    var command = new CreateUser(id: Guid.NewGuid(), username: "loremipsum", email: "lorem@ipsum.com", firstname: "lorem", lastname: "ipsum");
        //    var mockRepo = new Mock<IRepository<Infrastructure.Entities.User>>();
        //    var mockDbContext = new Mock<IDbContext>();
        //    mockDbContext.Setup(db => db.Users).Returns(mockRepo.Object);
        //    var sut = new CreateUserHandler(mockDbContext.Object);
        //    await sut.Handle(command);
        //    mockRepo.Verify(m => m.InsertOneAsync(It.IsAny<Infrastructure.Entities.User>()), Times.Once());
        //}


        //[Fact]
        //public async void CreateUser_ReturnUser()
        //{
        //    //Arange


        //    //Act
        //    var result = await _rep.CreateUser(It.IsAny<User>());


        //    //Assert
        //    Assert.Equal(It.IsAny<User>(), result);

        //}

        //[Fact]
        //public async void UpdateUser()
        //{
        //    //Arrange
        //    Irepo.Setup(service => service.Update(It.IsAny<User>()))
        //        .Returns(Task.FromResult<User>(new User
        //        {
        //            Id = "1",
        //            Familly = "hassanabadi",
        //            Mob = "989128303238",
        //            Name = "Mohammad",
        //            Password = "123",
        //        })
        //      );


        //    //Act
        //    User result = await _rep.UpdateUser(It.IsAny<User>());

        //    //Assert
        //    Irepo.Verify(x => x.Update(It.IsAny<User>()), Times.Once);
        //    //Assert.Equal(It.IsAny<User>(), result);
        //    Assert.IsType<User>(result);
        //}


        //[Fact]
        //public async void DeleteUser()
        //{
        //    //Arrange
        //    Irepo.Setup(service => service.Delete(It.IsAny<User>()))
        //        .Returns(Task.FromResult<bool>(true));


        //    //Act
        //    bool result = await _rep.DeleteUser(It.IsAny<User>());

        //    //Assert
        //    Irepo.Verify(x => x.Delete(It.IsAny<User>()), Times.Once);
        //    Assert.IsType<bool>(result);
        //}

        //[Fact]
        //public async void GetAllUser()
        //{
        //    //Arrange
        //    Irepo.Setup(service => service.GetAll())
        //        .Returns(Task.FromResult<IEnumerable<User>>(
        //                    new List<User>()
        //                    {
        //                        new User()
        //                        {
        //                             Id = "1",
        //                            Familly = "hassanabadi",
        //                            Mob = "989128303238",
        //                            Name = "Mohammad",
        //                            Password = "123",
        //                        }
        //                    }
        //       ));


        //    //Act
        //    IEnumerable<User> result = await _rep.GetAllUser();

        //    //Assert
        //    Irepo.Verify(x => x.GetAll(), Times.Once);
        //    Assert.IsType<List<User>>(result);
        //}

    }
}
