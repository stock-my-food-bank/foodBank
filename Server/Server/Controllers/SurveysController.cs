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
        public IActionResult Post([FromBody] SurveysPost survey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _surveysRepository.SubmitSurvey(survey.userId, survey.commentId);
            return Ok();
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