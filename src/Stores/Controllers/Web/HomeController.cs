using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stores.Services;

namespace Stores.Controllers.Web
{
    public class HomeController : Controller
    {
        private IStoreRepository _storeRepo;

        public HomeController(IStoreRepository storeRepo)
        {
            _storeRepo = storeRepo;
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

            return View(stores);
        }

        [HttpGet]
        [Route("/store/{storeNumber}")]
        public IActionResult Detail(int storeNumber)
        {
            var store = _storeRepo.GetStore(storeNumber);

            if (store == null)
            {
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
