using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemsController : ControllerBase
    {
        private readonly IFoodItemsRepository _foodItemsRepository;
        public FoodItemsController(IFoodItemsRepository foodItemRepository) 
        {
            _foodItemsRepository = foodItemRepository;
        }

        // Muphree - gets foodItems from Spoonacular, no input needed returns list of foodItems using foodItemsBasic model
        [HttpGet]
        [Route("/api/FoodItems")]
        public async Task<ActionResult<FoodItemsBasic>> GetAllFoodItemsFromSpoonacular()
        {
            var foodItems = await _foodItemsRepository.GetFoodItemsFromSpoonacular();
            if (foodItems == null)
            {
                return NotFound();
            }
            return Ok(foodItems);
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
