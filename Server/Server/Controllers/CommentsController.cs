using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Models;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsRepository _commentsRepository;
        public CommentsController( ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        //Murphree - input is a new comment using the CommentsPost Model, output is the commentId
        [HttpPost]
        public IActionResult Post([FromBody] CommentsPost newComment)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int? commentId = _commentsRepository.AddComment(newComment);

            //returns commentId to be given to other tables
            return Ok(commentId);
        }

        //Murphree - no inputs needed, output is a list of comments using the CommentsGet Model 
        [HttpGet]
        [Route("/api/Comments")]
        public ActionResult<List <CommentsGet>> GetAllComments()
        {
            List<CommentsGet> comments = _commentsRepository.GetAllComments();
            if (comments == null)
            {
                return NotFound();
            }
            return Ok(comments);
        }

        // for testing purposes
        [HttpGet("count")]
        public IActionResult Get()
        {
            var count = _commentsRepository.GetCount();
            return Ok(count);
        }
    }
}
