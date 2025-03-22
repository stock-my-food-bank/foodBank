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
    public class SurveyFoodItemResultsControllerTests
    {
        private readonly Mock<ISurveyFoodItemResultsRepository> _mockRepo;
        private readonly SurveyFoodItemResultsController _controller;

        public SurveyFoodItemResultsControllerTests()
        {
            _mockRepo = new Mock<ISurveyFoodItemResultsRepository>();
            _controller = new SurveyFoodItemResultsController(_mockRepo.Object);
        }

        [Fact]
        public void Post_InvalidModelState_ReturnsBadRequest()
        {
            // Arrange
            _controller.ModelState.AddModelError("error", "Invalid model");
            var surveyPost = new SurveyFoodItemResultsPost(1, true, false, 1);

            // Act
            var result = _controller.Post(surveyPost);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Post_ValidModelState_ReturnsOkWithSurveyResultId()
        {
            // Arrange
            var surveyPost = new SurveyFoodItemResultsPost(1, true, false, 1);
            _mockRepo.Setup(repo => repo.InsertSurvey(It.IsAny<SurveyFoodItemResultsInsert>()))
                     .Returns(100);

            // Act
            var result = _controller.Post(surveyPost);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(100, okResult.Value);
        }

        [Fact]
        public void Put_ReturnsOk()
        {
            // Arrange
            int id = 1;
            var surveyPut = new SurveyFoodItemResultsPut(1, 0);
            _mockRepo.Setup(repo => repo.TallyVotes(surveyPut, id))
                     .Returns(0);

            // Act
            var result = _controller.Put(id, surveyPut);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void GetVotes_ReturnsOkWithResults_WhenResultsExist()
        {
            // Arrange
            var resultsList = new List<SurveyFoodItemResultsGet>
            {
                new SurveyFoodItemResultsGet { surveyFoodItemResultsId = 1, surveyId = 1, foodItemId = 1, voteCountYes = 5, voteCountNo = 2, rank = 1, dateTime = DateTime.Now },
                new SurveyFoodItemResultsGet { surveyFoodItemResultsId = 2, surveyId = 1, foodItemId = 2, voteCountYes = 3, voteCountNo = 1, rank = 2, dateTime = DateTime.Now }
            };
            _mockRepo.Setup(repo => repo.GetVotes())
                     .Returns(resultsList);

            // Act
            var actionResult = _controller.GetVotes();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedResults = Assert.IsType<List<SurveyFoodItemResultsGet>>(okResult.Value);
            Assert.Equal(2, returnedResults.Count);
        }

        [Fact]
        public void GetVotes_ReturnsNotFound_WhenResultsAreNull()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetVotes())
                     .Returns((List<SurveyFoodItemResultsGet>)null);

            // Act
            var actionResult = _controller.GetVotes();

            // Assert
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public void Get_Count_ReturnsOkWithCount()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetCount())
                     .Returns(7);

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(7, okResult.Value);
        }
    }
}