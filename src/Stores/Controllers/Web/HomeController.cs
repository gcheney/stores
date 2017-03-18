using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Stores.Controllers.Web
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/stores")]
        public IActionResult Stores()
        {
            ViewData["Message"] = "All Stores.";

            return View();
        }

        [HttpGet]
        [Route("/store/{storeNumber}")]
        public IActionResult Detail(int storeNumber)
        {
            ViewData["Message"] = $"Your store id: {storeNumber}";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
