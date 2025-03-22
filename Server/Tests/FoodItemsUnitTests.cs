using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Server.Controllers;
using Server.Interfaces;
using Server.Models;
using Xunit;

namespace UnitTests
{
    public class FoodItemsControllerTests
    {
        private readonly Mock<IFoodItemsRepository> _mockFoodItemsRepo;
        private readonly FoodItemsController _controller;

        public FoodItemsControllerTests()
        {
            _mockFoodItemsRepo = new Mock<IFoodItemsRepository>();
            _controller = new FoodItemsController(_mockFoodItemsRepo.Object);
        }

        [Fact]
        public async Task GetAllFoodItemsFromSpoonacular_ReturnsOkWithProducts_WhenProductsExist()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { id = 1, title = "Product1", image = "img1.jpg", imageType = "jpg" },
                new Product { id = 2, title = "Product2", image = "img2.jpg", imageType = "jpg" }
            };
            _mockFoodItemsRepo.Setup(repo => repo.GetFoodItemsFromSpoonacular())
                              .ReturnsAsync(products);

            // Act
            var actionResult = await _controller.GetAllFoodItemsFromSpoonacular();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            var returnedProducts = Assert.IsType<List<Product>>(okResult.Value);
            Assert.Equal(2, returnedProducts.Count);
        }

        [Fact]
        public async void GetAllFoodItemsFromSpoonacular_ReturnsNotFound_WhenProductsAreNull()
        {
            // Arrange
            _mockFoodItemsRepo.Setup(repo => repo.GetFoodItemsFromSpoonacular())
                              .ReturnsAsync((List<Product>)null);

            // Act
            var actionResult = await _controller.GetAllFoodItemsFromSpoonacular();

            // Assert
            Assert.IsType<NotFoundResult>(actionResult.Result);
        }

        [Fact]
        public void Get_Count_ReturnsOkWithCount()
        {
            // Arrange
            _mockFoodItemsRepo.Setup(repo => repo.GetCount())
                              .Returns(4);

            // Act
            var result = _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(4, okResult.Value);
        }
    }
}
