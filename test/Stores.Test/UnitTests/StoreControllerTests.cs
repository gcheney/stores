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
using Stores.Controllers.Api;
using AutoMapper;

namespace Stores.Tests.UnitTests
{
    public class StoreControllerTests
    {
        public StoreControllerTests()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Store, StoreViewModel>().ReverseMap();
            });
        }

        [Fact]
        public void AddStore_ReturnsObjectResult_WhenValid()
        {
            Console.WriteLine("Running test: AddStore_ReturnsObjectResult_WhenValid");

            // Arrange
            var mockRepo = new Mock<IStoreRepository>();
            mockRepo.Setup(repo => repo.AddStore(new Store { StoreNumber = 1 })).Returns(true);
            var controller = new StoreController(mockRepo.Object, new LoggerFactory());

            // Act
            var result = controller.AddStore(new StoreViewModel { StoreNumber = 1 });

            // Assert
            Assert.IsAssignableFrom<ObjectResult>(result);
        }

        [Fact]
        public void AddStore_ReturnsBadRequestResult_WhenViewModelNull()
        {
            Console.WriteLine("Running test: AddStore_ReturnsBadRequestResult_WhenViewModelNull");

            // Arrange
            var mockRepo = new Mock<IStoreRepository>();
            mockRepo.Setup(repo => repo.AddStore(new Store { StoreNumber = 1 })).Returns(true);
            var controller = new StoreController(mockRepo.Object, new LoggerFactory());

            // Act
            var result = controller.AddStore(null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void UpdateStore_ReturnsNotFoundResult_WhenStoreDoesNotExist()
        {
            Console.WriteLine("Running test: UpdateStore_ReturnsNotFoundResult_WhenStoreDoesNotExist");

            // Arrange
            var mockRepo = new Mock<IStoreRepository>();
            mockRepo.Setup(repo => repo.UpdateStore(1, new Store { StoreName = "Test" })).Returns(false);
            var controller = new StoreController(mockRepo.Object, new LoggerFactory());

            // Act
            var result = controller.UpdateStore(2, new StoreViewModel { StoreName = "Test" });

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
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