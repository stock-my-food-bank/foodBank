using Microsoft.AspNetCore.Mvc;
using Moq;
using Server.Controllers;
using Server.Interfaces;
using Server.Models;
using Xunit;

namespace UnitTests
{
    public class UsersControllerTests
    {
        private readonly Mock<IUsersRepository> _mockUsersRepo;
        private readonly UsersController _controller;

        public UsersControllerTests()
        {
            _mockUsersRepo = new Mock<IUsersRepository>();
            _controller = new UsersController(_mockUsersRepo.Object);
        }

        [Fact]
        public void Post_ReturnsOkWithUserId()
        {
            // Arrange
            string role = "admin";
            _mockUsersRepo.Setup(repo => repo.InsertUser(It.IsAny<string>()))
                          .Returns(1);

            // Act
            var result = _controller.Post(role);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(1, okResult.Value);
        }

        [Fact]
        public void Get_ById_ReturnsOkWhenUserExists()
        {
            // Arrange
            int userId = 1;
            var user = new UsersGet { userId = userId, role = "admin" };
            _mockUsersRepo.Setup(repo => repo.GetUser(userId))
                          .Returns(user);

            // Act
            var result = _controller.Get(userId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedUser = Assert.IsType<UsersGet>(okResult.Value);
            Assert.Equal(userId, returnedUser.userId);
        }

        [Fact]
        public void Get_ById_ReturnsNotFoundWhenUserDoesNotExist()
        {
            // Arrange
            int userId = 1;
            _mockUsersRepo.Setup(repo => repo.GetUser(userId))
                          .Returns((UsersGet)null);

            // Act
            var result = _controller.Get(userId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Get_Count_ReturnsOkWithCount()
        {
            // Arrange
            _mockUsersRepo.Setup(repo => repo.GetCount())
                          .Returns(5);

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(5, okResult.Value);
        }
    }
}
