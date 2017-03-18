using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Stores.Controllers.Api
{
    public class StoreController : Controller
    {
        [HttpPost("api/store/add")]
        public IActionResult AddStore()
        {
            return Ok();
        }

        [HttpPost("api/store/{storeNumber}")]
        public IActionResult UpdateStore(int storeNumber)
        {
            return Ok();
        }

        [HttpDelete("api/store/{storeNumber}")]
        public IActionResult DeleteStore(int storeNumber)
        {
            return NoContent();
        }
    }
}