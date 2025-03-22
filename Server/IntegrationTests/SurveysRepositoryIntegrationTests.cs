using System;
using System.Data.SQLite;
using Server.Models;
using Server.Repositories;
using Xunit;

namespace IntegrationTests
{
    public class SurveysRepositoryIntegrationTests 
    {
        private readonly SurveysRepository _repository;

        public SurveysRepositoryIntegrationTests()
        {
            // Generate a unique connection string for each test.
            string connection = Guid.NewGuid().ToString().Replace("-", "");
            // Instantiate the repository with the test connection string.
            _repository = new SurveysRepository($"Data Source={connection}.db; Version=3;");
        }

        [Fact]
        public void SubmitSurvey_InsertsSurveyAndReturnsId()
        {
            // Arrange: Create a survey post model with dummy userId and commentId.
            SurveysPost surveyPost = new SurveysPost(1, 1);

            // Act
            int? id = _repository.SubmitSurvey(surveyPost);

            // Assert
            Assert.NotNull(id);
            int count = _repository.GetCount();
            Assert.Equal(1, count);
        }
    }
}
