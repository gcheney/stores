using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stores.Services;

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
                return View("Error");
            }

            return View(stores);
        }

        [HttpGet]
        [Route("/store/{storeNumber}")]
        public IActionResult Detail(int storeNumber)
        {
            var store = _storeRepo.GetStore(storeNumber);

            if (store == null)
            {
                _logger.LogInformation($"Unable to find store with number: {storeNumber}");
                return NotFound();
            }

            return View(store);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
