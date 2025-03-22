using System;
using System.Collections.Generic;
using System.Data.SQLite;
using NuGet.Protocol.Plugins;
using Server.Models;
using Server.Repositories;
using Xunit;

namespace IntegrationTests
{
    public class CommentsRepositoryIntegrationTests
    {
        private readonly CommentsRepository _repository;

        public CommentsRepositoryIntegrationTests()
        {
            // Generate a unique connection string for each test.
            string connection = Guid.NewGuid().ToString().Replace("-", "");
            // Instantiate the repository with the test connection string.
            _repository = new CommentsRepository($"Data Source={connection}.db; Version=3;");
        }

        [Fact]
        public void AddComment_InsertsCommentAndIncreasesCount()
        {
            // Arrange
            var comment = new CommentsPost("Test integration comment");

            // Act
            int? id = _repository.AddComment(comment);

            // Assert
            Assert.NotNull(id);
            int count = _repository.GetCount();
            Assert.Equal(1, count);
        }

        [Fact]
        public void GetAllComments_ReturnsInsertedComment()
        {
            // Arrange: Insert a comment.
            var comment = new CommentsPost("Test integration comment");
            int? id = _repository.AddComment(comment);

            // Act: Retrieve comments.
            List<CommentsGet> comments = _repository.GetAllComments();

            // Assert
            Assert.NotNull(comments);
            Assert.Single(comments);
            Assert.Equal("Test integration comment", comments[0].comment);
        }
    }
}
