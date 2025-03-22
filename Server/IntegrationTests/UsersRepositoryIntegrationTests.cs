using System;
using System.Data.SQLite;
using Server.Models;
using Server.Repositories;
using Xunit;

namespace IntegrationTests
{
    public class UsersRepositoryIntegrationTests
    {
        // Define a test-specific connection string.
        private readonly UsersRepository _repository;

        public UsersRepositoryIntegrationTests()
        {
            string connection = Guid.NewGuid().ToString().Replace("-", "");
            // Instantiate the repository using the test connection string.
            _repository = new UsersRepository($"Data Source={connection}.db; Version=3;");
        }

        [Fact]
        public void GetCount_ReturnsZero_WhenTableIsEmpty()
        {
            // Act
            int count = _repository.GetCount();

            // Assert: Expect count to be zero when no users have been inserted.
            Assert.Equal(0, count);
        }

        [Fact]
        public void InsertUser_InsertsUserAndReturnsId()
        {
            // Arrange
            string role = "test role";

            // Act: Insert a user.
            int? userId = _repository.InsertUser(role);

            // Assert: userId should not be null and count should be 1.
            Assert.NotNull(userId);
            int count = _repository.GetCount();
            Assert.Equal(1, count);
        }

        [Fact]
        public void GetUser_ReturnsCorrectUser()
        {
            // Arrange: Insert a user first.
            string role = "test role";
            int? userId = _repository.InsertUser(role);
            Assert.NotNull(userId);

            // Act: Retrieve the inserted user.
            UsersGet user = _repository.GetUser(userId.Value);

            // Assert: Verify that the user is not null and has the expected role.
            Assert.NotNull(user);
            Assert.Equal(role, user.role);
            Assert.Equal(userId.Value, user.userId);
        }
    }
}
