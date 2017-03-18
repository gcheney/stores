using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Stores.Services;
using Stores.Models;
using Stores.Controllers.Web;

namespace Stores.Tests.UnitTests
{
    public class HomeControllerTests
    {
        [Fact]
        public async Task Index_ReturnsAViewResult()
        {
            Console.WriteLine("Running test: Index_ReturnsAViewResult");

            // Arrange
            var mockRepo = new Mock<IStoreRepository>();
            var controller = new HomeController(mockRepo.Object, new LoggerFactory());

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Stores_ReturnsAViewResult_WithAListOfStores()
        {
            Console.WriteLine("Running test: Stores_ReturnsAViewResult_WithAListOfStores");

            // Arrange
            var mockRepo = new Mock<IStoreRepository>();
            mockRepo.Setup(repo => repo.GetAllStores())
                .Returns(GetTestStores());
            var controller = new HomeController(mockRepo.Object, new LoggerFactory());

            // Act
            var result = controller.Stores();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Store>>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public async Task Stores_ReturnsErrorViewResult_WhenStoreDataIsNull()
        {
            Console.WriteLine("Running test: Stores_ReturnsErrorViewResult_WhenStoreDataIsNull");

            // Arrange
            var mockRepo = new Mock<IStoreRepository>();
            mockRepo.Setup(repo => repo.GetAllStores())
                .Returns(GetNullStores());
            var controller = new HomeController(mockRepo.Object, new LoggerFactory());

            // Act
            var result = controller.Stores();

            // Assert
            var errorResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Error", errorResult.ViewName);
        }

        

        private IEnumerable<Store> GetTestStores()
        {
            var stores = new List<Store>();

            stores.Add(new Store()
            {
                StoreNumber = 1,
                StoreName = "Austin",
                StoreManagerName = "Joe Smith",
                OpeningTime = "7:00 AM",
                ClosingTime = "8:00pm"
            });

            stores.Add(new Store()
            {
                StoreNumber = 2,
                StoreName = "San Antonio",
                StoreManagerName = "Jack Smith",
                OpeningTime = "8:00 AM",
                ClosingTime = "9:00pm"
            });

            stores.Add(new Store()
            {
                StoreNumber = 3,
                StoreName = "Dallas",
                StoreManagerName = "James Smith",
                OpeningTime = "9:00 AM",
                ClosingTime = "10:00pm"
            });

            return stores;
        }

        private IEnumerable<Store> GetNullStores()
        {
            return null;
        }
    }
}