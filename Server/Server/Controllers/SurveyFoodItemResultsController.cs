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
        public IActionResult Post([FromBody]SurveyFoodItemResultsPost surveyFoodItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            SurveyFoodItemResultsInsert surveyFoodItemResult = new SurveyFoodItemResultsInsert {
                foodItemId = surveyFoodItem.foodItemId,
                surveyId = surveyFoodItem.surveyId,
                voteCountYes = surveyFoodItem.voteCountYes? 1 : 0,
                voteCountNo = surveyFoodItem.voteCountNo? 1 : 0
            };
            int? surveyResultId =  _surveyFoodItemResultsRepository.InsertSurvey(surveyFoodItemResult);
            return Ok(surveyResultId);
        }

        [HttpPut("{id}")] 
        //FromBody will send info from response of form
        //expect from FE - clicking the yes or no increments result on FE and is sent as a whole to BE
        public IActionResult Put(int id, [FromBody] SurveyFoodItemResultsPut surveyFoodItemResult)
        {

            _surveyFoodItemResultsRepository.TallyVotes(surveyFoodItemResult, id);
            return Ok();
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
