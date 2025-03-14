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
            int surveyResultId = _surveyFoodItemResultsRepository.InsertSurvey(surveyFoodItem);
            return Ok(surveyResultId);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SurveyFoodItemResultsPut surveyFoodItemResult)
        {

            var result = _surveyFoodItemResultsRepository.TallyVotes(surveyFoodItemResult, id);
            return Ok(result);
        }

        [HttpGet()]
        [Route("/api/SurveyFoodItemResults")]
        public ActionResult<List<SurveyFoodItemResultsGet>> GetVotes()
        {
            var results = _surveyFoodItemResultsRepository.GetVotes();
            if(results == null)
            {
                return NotFound();
            }
            return Ok(results);
        }

        //testing connection
        [HttpGet("count")]
        public IActionResult Get()
        {
            var count = _surveyFoodItemResultsRepository.GetCount();
            return Ok(count);
        }
    }
}
