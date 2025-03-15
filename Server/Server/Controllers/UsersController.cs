using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Repositories;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersRepository _usersRepository;
        public UsersController()
        {
            _usersRepository = new UsersRepository();
        }

        [HttpPost]
        public IActionResult Post(string role)
        {
            int? userId = _usersRepository.InsertUser(role);
            return Ok(userId);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            UsersGet user = _usersRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        //for testing purposes
        [HttpGet]
        public IActionResult Get()
        {
            var count = _usersRepository.GetCount();
            return Ok(count);
        }
    }
}
