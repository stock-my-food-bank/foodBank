﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("count")]
        public IActionResult Get()
        {
            var count = _commentsRepository.GetCount();
            return Ok(count);
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
    }
}
