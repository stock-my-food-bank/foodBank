using System;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Server.Controllers;
using Server.Interfaces;
using Server.Models;
using Xunit;

namespace UnitTests
{
    public class SurveysControllerTests
    {
        private readonly Mock<ICommentsRepository> _mockCommentsRepo;
        private readonly Mock<ISurveysRepository> _mockSurveysRepo;
        private readonly SurveysController _controller;

        public SurveysControllerTests()
        {
            _mockCommentsRepo = new Mock<ICommentsRepository>();
            _mockSurveysRepo = new Mock<ISurveysRepository>();
            // UsersRepository is instantiated inside the controller.
            _controller = new SurveysController(_mockCommentsRepo.Object, _mockSurveysRepo.Object);
        }

        [Fact]
        public void Post_ValidComment_ReturnsOkWithSurveyId()
        {
            // Arrange
            string comment = "Test survey comment";
            _mockCommentsRepo.Setup(repo => repo.AddComment(It.IsAny<CommentsPost>()))
                             .Returns(10);
            _mockSurveysRepo.Setup(repo => repo.SubmitSurvey(It.IsAny<SurveysPost>()))
                             .Returns(30);
            // Note: UsersRepository is not mocked here and is assumed to work properly.

            // Act
            var result = _controller.Post(comment);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(30, okResult.Value);
        }

        [Fact]
        public void Post_FailedToAddComment_ThrowsException()
        {
            // Arrange
            string comment = "Test survey comment";
            _mockCommentsRepo.Setup(repo => repo.AddComment(It.IsAny<CommentsPost>()))
                             .Returns((int?)null);

            // Act & Assert
            Assert.Throws<Exception>(() => _controller.Post(comment));
        }

        [Fact]
        public void Get_Count_ReturnsOkWithCount()
        {
            // Arrange
            _mockSurveysRepo.Setup(repo => repo.GetCount())
                             .Returns(7);

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(7, okResult.Value);
        }
    }
}