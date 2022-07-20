
using Micro.Services.ACC.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using FluentAssertions;
using Micro.Services.ACC.Services;
using Moq;
using Micro.Services.ACC.Entity;
using Micro.Services.ACC.DTOs;
using MassTransit;

namespace Micro.Services.ACC.XUnit
{
    public class TestGroupController
    {
        Mock<IGroupService> MockGroupService;
        Mock<IPublishEndpoint> MockGroupServiceMas;

        GroupController controller;

        public TestGroupController()
        {
            MockGroupService = new Mock<IGroupService>();
            MockGroupServiceMas = new Mock<IPublishEndpoint>();
            controller = new GroupController(MockGroupService.Object, MockGroupServiceMas.Object);
        }

        [Fact]
        public async Task Get_Return_200()
        {
            //Arrange


            MockGroupService.Setup(service => service.GetAllGroups())
                .ReturnsAsync(new List<Group>() {
                new Group()
                {
                    Id = "1",
                    GroupCode="123",
                    GroupName="test"
                }
                });


            //Act
            var result = (OkObjectResult)await controller.Get();

            //Assert
            result.StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task Get_InvoceService()
        {
            //Arrange
            //var MockGroupService = new Mock<IGroupService>();
            //var controller = new GroupController(MockGroupService.Object);

            MockGroupService.Setup(Service => Service.GetAllGroups())
                 .ReturnsAsync(new List<Group>() {
                new Group()
                {
                    Id = "1",
                    GroupCode="123",
                    GroupName="test"
                }
                });

            //Act
            await controller.Get();

            //Assert

            MockGroupService.Verify(service => service.GetAllGroups(), Times.Once);

        }

        [Fact]
        public async Task Get_Result_ListGroups()
        {
            //Arrange
            //var MockGroupService = new Mock<IGroupService>();
            //var controller = new GroupController(MockGroupService.Object);

            MockGroupService.Setup(Service => Service.GetAllGroups())
                 .ReturnsAsync(new List<Group>() {
                new Group()
                {
                    Id ="1",
                    GroupCode="123",
                    GroupName="test"
                }
                });

            //Act
            var result = (OkObjectResult)await controller.Get();

            //Assert
            result.Value.Should().BeOfType<List<Group>>();


        }

        [Fact]
        public async void creategroup()
        {
            //Arrange
            var GroupDTO = new GroupDTO() { GroupName = "test" ,GroupCode="10"};
            
            MockGroupService.Setup(x => x.CreateGroup(GroupDTO))
                .ReturnsAsync(new bool());


            //Act
            var result = (OkObjectResult)await controller.CreateGroup(GroupDTO);


            //Assert
            result.Value.Should().NotBeNull();
            result.Value.Should().Be(GroupDTO);

        }


        [Fact]
        public async Task Creategroup_NullValue()
        {
            //Arrange 
            GroupDTO GroupDTO;

            //Act
            var exeption = await Assert.ThrowsAsync<ArgumentNullException>(() => controller.CreateGroup(null));

            //Assert
            Assert.Equal("request", exeption.ParamName);
        }

    }
}
