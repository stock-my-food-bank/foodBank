using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repositories;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private CommentsRepository _commentsRepository;
        public CommentsController()
        {
            _commentsRepository = new CommentsRepository();
        }

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
