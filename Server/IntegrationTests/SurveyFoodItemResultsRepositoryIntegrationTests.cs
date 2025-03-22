using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Server.Models;
using Server.Repositories;
using Xunit;

namespace IntegrationTests
{
    public class SurveyFoodItemResultsRepositoryIntegrationTests 
    {
        private readonly SurveyFoodItemResultsRepository _repository;

        public SurveyFoodItemResultsRepositoryIntegrationTests()
        {
            string connection = Guid.NewGuid().ToString().Replace("-", "");
            // Instantiate the repository using the test connection string.
            _repository = new SurveyFoodItemResultsRepository($"Data Source={connection}.db; Version=3;");
        }

        [Fact]
        public void InsertSurvey_InsertsRecordAndReturnsId()
        {
            // Arrange: Create a survey food item results insert model.
            var insertModel = new SurveyFoodItemResultsInsert
            {
                foodItemId = 1,
                surveyId = 1,
                voteCountYes = 1,
                voteCountNo = 0
            };

            // Act
            int? id = _repository.InsertSurvey(insertModel);

            // Assert
            Assert.NotNull(id);
            int count = _repository.GetCount();
            Assert.Equal(1, count);
        }

        [Fact]
        public void TallyVotes_UpdatesVoteCounts()
        {
            // Arrange: Insert a record first.
            var insertModel = new SurveyFoodItemResultsInsert
            {
                foodItemId = 1,
                surveyId = 1,
                voteCountYes = 1,
                voteCountNo = 0
            };
            int? id = _repository.InsertSurvey(insertModel);
            Assert.NotNull(id);

            // Act: Update the vote counts.
            var updateModel = new SurveyFoodItemResultsPut(2, 1);
            int result = _repository.TallyVotes(updateModel, id.Value);

            // Assert: Expect TallyVotes to return 0 on success.
            Assert.Equal(0, result);

            // Optionally, retrieve votes and validate the updated values.
            List<SurveyFoodItemResultsGet> votes = _repository.GetVotes();
            Assert.NotEmpty(votes);
        }
    }
}
