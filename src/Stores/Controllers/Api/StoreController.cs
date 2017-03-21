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
        
        // POST: /api/store/add
        [HttpPost("api/store/add")]
        public IActionResult AddStore([FromBody] StoreViewModel storeViewModel)
        {
            if (storeViewModel == null)
            {
                _logger.LogError("No data provided");
                return BadRequest();
            }

            if (storeViewModel.StoreNumber == 0)
            {
                ModelState.AddModelError("StoreNumber", "Invalid or null store number supplied");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid store data was provided");
                return BadRequest(ModelState);
            }

            var store = Mapper.Map<Store>(storeViewModel);

            if (_storeRepo.AddStore(store))
            {
                // store was successfully created
                _logger.LogInformation($"New store added with #{store.StoreNumber}");
                return CreatedAtRoute("Detail", new {
                    storeNumber = store.StoreNumber
                }, store);
            }

            return StatusCode(409, new {
                Message = "A resource with the specified StoreNumber already exist"
            });  
        }

        // POST: /api/store/1
        [HttpPost("api/store/{storeNumber}")]
        public IActionResult UpdateStore(int storeNumber, [FromBody] StoreViewModel storeViewModel)
        {
            if (storeViewModel == null)
            {
                _logger.LogError("No data provided");
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid store data was provided");
                return BadRequest(ModelState);
            }

            var store = Mapper.Map<Store>(storeViewModel);

            if (_storeRepo.UpdateStore(storeNumber, store))
            {
                // store data was updated
                _logger.LogInformation($"Store number {storeNumber} has been updated");
                return NoContent();
            }
            
            return NotFound(new {
                Message = "A resource with the specified storeNumber could not be located"
            });
        }

        // DELETE: /api/store/1
        [HttpDelete("api/store/{storeNumber}")]
        public IActionResult DeleteStore(int storeNumber)
        {
            if (_storeRepo.DeleteStore(storeNumber))
            {
                _logger.LogInformation($"Store number {storeNumber} has been deleted");
                return NoContent();
            }

            return NotFound(new {
                Message = "A resource with the specified storeNumber could not be located"
            });
        }
    }
}