using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Api
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersRepository _userRepo;

        public UsersController(UsersRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            var users = _userRepo.GetUsers();

            return Ok(users);
        }

        [HttpGet, Route("{id:guid}")]
        public IActionResult GetUserById(Guid id)
        {
            var user = _userRepo.GetUserById(id);

            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            _userRepo.CreateUser(user);

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] User user)
        {
            _userRepo.UpdateUser(user);

            return Ok();
        }

        [HttpDelete, Route("{id:guid}")]
        public IActionResult DeleteUser(Guid id)
        {
            _userRepo.DeleteUser(id);

            return Ok();
        }
    }
}
