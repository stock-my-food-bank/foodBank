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
        private CommentsRepository _commentsRepository;
        private UsersRepository _usersRepository;
        public SurveysController()
        {
            _surveysRepository = new SurveysRepository();
            _commentsRepository = new CommentsRepository();
            _usersRepository = new UsersRepository();
        }

        [HttpPost]
        public IActionResult Post([FromBody] string comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            CommentsPost newComment = new CommentsPost(comment);
            int? commentId = _commentsRepository.AddComment(newComment);

            if (commentId == null) {
                throw new Exception("failed to save comment.");
            }
            int? newUserId = _usersRepository.InsertUser("user");

            if (newUserId == null)
            {
                throw new Exception("failed to save user");
            }
            SurveysPost newSurvey = new SurveysPost((int)newUserId, (int)commentId);
            
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