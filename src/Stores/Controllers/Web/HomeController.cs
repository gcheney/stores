using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stores.Services;
using Stores.ViewModels;
using AutoMapper;

namespace Stores.Controllers.Web
{
    public class HomeController : Controller
    {
        private IStoreRepository _storeRepo;
        private ILogger<HomeController> _logger;

        public HomeController(IStoreRepository storeRepo, ILoggerFactory loggerFactory)
        {
            _storeRepo = storeRepo;
            _logger = loggerFactory.CreateLogger<HomeController>();
        } 
        
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/stores")]
        public IActionResult Stores()
        {
            var stores = _storeRepo.GetAllStores();

            if (stores == null)
            {
                _logger.LogError("An error occured retrieving store data");
                return View("Error");
            }

            var viewModel = Mapper.Map<IEnumerable<StoreViewModel>>(stores);
            return View(viewModel);
        }

        [HttpGet]
        [Route("/store/{storeNumber}", Name="Detail")]
        public IActionResult Detail(int storeNumber)
        {
            var store = _storeRepo.GetStore(storeNumber);

            if (store == null)
            {
                _logger.LogInformation($"Unable to find store with number: {storeNumber}");
                return NotFound();
            }

            var viewModel = Mapper.Map<StoreViewModel>(store);
            return View(viewModel);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
