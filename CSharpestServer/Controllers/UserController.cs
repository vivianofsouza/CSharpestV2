using Microsoft.AspNetCore.Mvc;
using CSharpestServer.Models;
using CSharpestServer.Services;
using CSharpestServer.Services.Interfaces;
using System.Linq;
using CSharpestServer.Parameters;

namespace CSharpestServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public Task<IActionResult> GetUser()
        {
            return Ok();
        }

        // POST api/<UserController>
        [HttpPost("Login")]
        public Task<IActionResult> Login([FromBody] AccountRequest req)
        {
            var response = _userService.Login(req)


            return(null ? (Task<IActionResult>)Unauthorized("User not found.") : Ok(resp));
        }

        // POST api/<UserController>
        [HttpPost("CreateAccount")]
        public void CreateAccount([FromBody] string value)
        {

        }

        // POST api/<UserController>
        [HttpPost("Logout")]
        public Task<IActionResult> Logout()
        {
            
        }
    }
}
