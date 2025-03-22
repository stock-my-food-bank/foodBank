using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Server.Controllers;
using Server.Interfaces;
using Server.Models;
using Xunit;

namespace UnitTests
{
    public class CommentsControllerTests
    {
        private readonly Mock<ICommentsRepository> _mockCommentsRepo;
        private readonly CommentsController _controller;

        public CommentsControllerTests()
        {
            // Set up a mock repository.
            _mockCommentsRepo = new Mock<ICommentsRepository>();
            _controller = new CommentsController(_mockCommentsRepo.Object);
        }

        [Fact]
        public void Post_InvalidModelState_ReturnsBadRequest()
        {
            // Arrange: make the ModelState invalid.
            _controller.ModelState.AddModelError("error", "Model error");
            var newComment = new CommentsPost("Test comment");

            // Act
            var result = _controller.Post(newComment);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Post_ValidModelState_ReturnsOkWithCommentId()
        {
            // Arrange
            var newComment = new CommentsPost("Test comment");
            _mockCommentsRepo
                .Setup(repo => repo.AddComment(It.IsAny<CommentsPost>()))
                .Returns(1);  // assume repository returns comment ID 1

            // Act
            var result = _controller.Post(newComment);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(1, okResult.Value);
        }

        [Fact]
        public void GetAllComments_ReturnsOkWithComments_WhenCommentsExist()
        {
            // Arrange
            var commentsList = new List<CommentsGet>
            {
                new CommentsGet { commentId = 1, comment = "First comment", dateTime = DateTime.Now },
                new CommentsGet { commentId = 2, comment = "Second comment", dateTime = DateTime.Now }
            };
            _mockCommentsRepo
                .Setup(repo => repo.GetAllComments())
                .Returns(commentsList);

            // Act
            var actionResult = _controller.GetAllComments();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedComments = Assert.IsType<List<CommentsGet>>(okResult.Value);
            Assert.Equal(2, returnedComments.Count);
        }

        [Fact]
        public void GetAllComments_ReturnsNotFound_WhenNoCommentsExist()
        {
            // Arrange: simulate repository returning null.
            _mockCommentsRepo
                .Setup(repo => repo.GetAllComments())
                .Returns((List<CommentsGet>)null);

            // Act
            var actionResult = _controller.GetAllComments();

            // Assert
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public void GetCount_ReturnsOkWithCount()
        {
            // Arrange
            _mockCommentsRepo
                .Setup(repo => repo.GetCount())
                .Returns(5);

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(5, okResult.Value);
        }
    }
}