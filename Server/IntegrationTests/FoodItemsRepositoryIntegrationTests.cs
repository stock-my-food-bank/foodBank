using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Server.Models;
using Server.Repositories;
using Xunit;

namespace IntegrationTests
{
    public class FoodItemsRepositoryIntegrationTests
    {
        private readonly FoodItemsRepository _repository;

        public FoodItemsRepositoryIntegrationTests()
        {
            // Generate a unique connection string for each test.
            string connection = Guid.NewGuid().ToString().Replace("-", "");
            // Instantiate the repository with the test connection string.
            _repository = new FoodItemsRepository($"Data Source={connection}.db; Version=3;");
        }

        [Fact]
        public void GetCount_ReturnsZero_WhenTableIsEmpty()
        {
            // Act
            int count = _repository.GetCount();

            // Assert: Expect count to be zero in an empty table.
            Assert.Equal(0, count);
        }
    }
}