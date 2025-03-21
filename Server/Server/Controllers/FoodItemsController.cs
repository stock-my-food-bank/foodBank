using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repositories;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemsController : ControllerBase
    {
        private FoodItemsRepository _foodItemsRepository;
        public FoodItemsController() 
        {
            _foodItemsRepository = new FoodItemsRepository();
        }

        // Muphree - gets foodItems from Spoonacular, no input needed returns list of foodItems using foodItemsBasic model
        [HttpGet]
        [Route("/api/FoodItems")]
        public ActionResult<FoodItemsBasic> GetAllFoodItemsFromSpoonacular()
        {
            var foodItems = _foodItemsRepository.GetFoodItemsFromSpoonacular();
            if (foodItems == null)
            {
                return NotFound();
            }
            return Ok(foodItems.Result);
        }

        //for testing connection purposes
        [HttpGet("count")]
        public IActionResult Get()
        {
            var count = _foodItemsRepository.GetCount();
            return Ok(count);
        }
    }
}
