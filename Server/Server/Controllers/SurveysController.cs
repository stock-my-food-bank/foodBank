using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repositories;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveysController : ControllerBase
    {
        private SurveysRepository _surveysRepository;
        public SurveysController()
        {
            _surveysRepository = new SurveysRepository();
        }

        [HttpPost]
        public IActionResult Post(int userId, int commentId)
        {
            SurveysPost newSurvey = new SurveysPost(userId, commentId);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int? surveyID =_surveysRepository.SubmitSurvey(newSurvey);
            return Ok(surveyID);
        }

        //for testing purposes
        [HttpGet("count")]
        public IActionResult Get()
        {
            var count = _surveysRepository.GetCount();
            return Ok(count);
        }
    }
}