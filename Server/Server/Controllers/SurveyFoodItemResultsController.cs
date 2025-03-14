using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repositories;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyFoodItemResultsController : ControllerBase
    {
        private SurveyFoodItemResultsRepository _surveyFoodItemResultsRepository;
        public SurveyFoodItemResultsController()
        {
            _surveyFoodItemResultsRepository = new SurveyFoodItemResultsRepository();
        }


        [HttpPost]
        public IActionResult Post([FromBody] SurveyFoodItemResultsPost surveyFoodItem)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int surveyResultId = _surveyFoodItemResultsRepository.SurveyFoodItemResultsInsert(surveyFoodItem);
            return Ok(surveyResultId);
        }
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    return Ok("value");
        //}
        //[HttpPost]
        //public IActionResult Post([FromBody] string value)
        //{
        //    return Ok();
        //}
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] string value)
        //{
        //    return Ok();
        //}
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    return Ok();
        //}

        //testing connection
        [HttpGet("count")]
        public IActionResult Get()
        {
            var count = _surveyFoodItemResultsRepository.GetCount();
            return Ok(count);
        }
    }
}
