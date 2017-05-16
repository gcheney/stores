using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using Stores.Services;
using Stores.Models;
using Stores.ViewModels;
using Stores.Controllers.Web;
using AutoMapper;

namespace Stores.Tests.UnitTests
{
    public class HomeControllerTests
    {
        public HomeControllerTests()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Store, StoreViewModel>().ReverseMap();
            });
        }

        [Fact]
        public void Index_ReturnsAViewResult()
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
        public void Stores_ReturnsAViewResult_WithAListOfStores()
        {
            Console.WriteLine("Running test: Stores_ReturnsAViewResult_WithAListOfStores");

            // Arrange
            var mockRepo = new Mock<IStoreRepository>();
            mockRepo.Setup(repo => repo.GetAllStores()).Returns(GetTestStores());
            var controller = new HomeController(mockRepo.Object, new LoggerFactory());

            // Act
            var result = controller.Stores();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StoreViewModel>>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());
        }

        [Fact]
        public void Stores_ReturnsErrorViewResult_WhenStoreDataIsNull()
        {
            Console.WriteLine("Running test: Stores_ReturnsErrorViewResult_WhenStoreDataIsNull");

            // Arrange
            var mockRepo = new Mock<IStoreRepository>();
            mockRepo.Setup(repo => repo.GetAllStores()).Returns(GetNullStores());
            var controller = new HomeController(mockRepo.Object, new LoggerFactory());

            // Act
            var result = controller.Stores();

            // Assert
            var errorResult = Assert.IsType<ViewResult>(result);
            Assert.Equal("Error", errorResult.ViewName);
        }

        [Fact]
        public void Detail_ReturnsViewResult_WithStore()
        {
            Console.WriteLine("Running test: Detail_ReturnsViewResult_WithStore");

            // Arrange
            var storeNumber = 1;
            var mockRepo = new Mock<IStoreRepository>();
            mockRepo.Setup(repo => repo.GetStore(storeNumber))
                .Returns(GetTestStores().Where(s => s.StoreNumber == storeNumber).FirstOrDefault());
            var controller = new HomeController(mockRepo.Object, new LoggerFactory());

            // Act
            var result = controller.Detail(storeNumber);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<StoreViewModel>(viewResult.ViewData.Model);
            Assert.Equal(storeNumber, model.StoreNumber);
        }

        [Fact]
        public void Detail_ReturnsNoutFoundResult_WhenStoreIsNull()
        {
            Console.WriteLine("Running test: Detail_ReturnsNoutFoundResult_WhenStoreIsNull");

            // Arrange
            var storeNumber = 11;
            var mockRepo = new Mock<IStoreRepository>();
            mockRepo.Setup(repo => repo.GetStore(storeNumber))
                .Returns(GetTestStores().Where(s => s.StoreNumber == storeNumber).FirstOrDefault());
            var controller = new HomeController(mockRepo.Object, new LoggerFactory());

            // Act
            var result = controller.Detail(storeNumber);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        private IEnumerable<Store> GetTestStores()
        {
            var stores = new List<Store>()
            {
                new Store()
                {
                    StoreNumber = 1,
                    StoreName = "Austin",
                    StoreManagerName = "Joe Smith",
                    OpeningTime = "7:00 AM",
                    ClosingTime = "8:00pm"
                },
                new Store()
                {
                    StoreNumber = 2,
                    StoreName = "San Antonio",
                    StoreManagerName = "Jack Smith",
                    OpeningTime = "8:00 AM",
                    ClosingTime = "9:00pm"
                },
                new Store()
                {
                    StoreNumber = 2,
                    StoreName = "San Antonio",
                    StoreManagerName = "Jack Smith",
                    OpeningTime = "8:00 AM",
                    ClosingTime = "9:00pm"
                }
            };

            return stores;
        }

        private IEnumerable<Store> GetNullStores()
        {
            return null;
        }
    }
}
