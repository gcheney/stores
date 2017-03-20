using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stores.Models;
using Stores.ViewModels;
using Stores.Services;
using AutoMapper;

namespace Stores.Controllers.Api
{
    public class StoreController : Controller
    {
        private IStoreRepository _storeRepo;
        private ILogger<StoreController> _logger;

        public StoreController(IStoreRepository storeRepo, ILoggerFactory loggerFactory)
        {
            _storeRepo = storeRepo;
            _logger = loggerFactory.CreateLogger<StoreController>();
        } 
        
        [HttpPost("api/store/add")]
        public IActionResult AddStore([FromBody] StoreViewModel storeViewModel)
        {
            if (storeViewModel == null)
            {
                _logger.LogInformation("No data provided");
                return BadRequest();
            }

            if (storeViewModel.StoreNumber == 0)
            {
                ModelState.AddModelError("StoreNumber", "Invalid or null store number supplied");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Invalid store data was provided");
                return BadRequest(ModelState);
            }

            var store = Mapper.Map<Store>(storeViewModel);

            if (_storeRepo.AddStore(store))
            {
                // store was successfully created
                return CreatedAtRoute("Detail", new {
                    storeNumber = store.StoreNumber
                }, store);
            }

            return StatusCode(409, new {
                Message = "A resource with the specified StoreNumber already exist"
            });  
        }

        [HttpPost("api/store/{storeNumber}")]
        public IActionResult UpdateStore(int storeNumber, [FromBody] StoreViewModel storeViewModel)
        {
            if (storeViewModel == null)
            {
                _logger.LogInformation("No data provided");
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                _logger.LogInformation("Invalid store data was provided");
                return BadRequest(ModelState);
            }

            var store = Mapper.Map<Store>(storeViewModel);

            if (_storeRepo.UpdateStore(storeNumber, store))
            {
                // store data was updated
                return NoContent();
            }
            
            return NotFound(new {
                Message = "A resource with the specified storeNumber could not be located"
            });
        }

        [HttpDelete("api/store/{storeNumber}")]
        public IActionResult DeleteStore(int storeNumber)
        {
            if (_storeRepo.DeleteStore(storeNumber))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}