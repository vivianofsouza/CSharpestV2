using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CSharpestServer.Models;
using CSharpestServer.Services.Interfaces;
using CSharpestServer.Services;
using System.Web.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CSharpestServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly StoreContext _context;
        private readonly IUsersService _usersService;

        public UsersController(StoreContext storeContext, UsersService usersService)
        {
            this._usersService = usersService;
            this._context = storeContext;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Getusers()
        {
            try
            {
                await _usersService.GetAllAsync();
            }
            catch
            {
                throw;
            }
            return Ok();
        }

        // POST /api/Users/Login
        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login([FromForm] string email, [FromForm] string password)
        {
            try
            {
                var user = await _usersService.Login(email, password);
                return Ok(user);
            }
            catch
            {
                throw;
            } 
        }

        // GET: api/Users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser([FromForm] Guid id)
        {
          if (_context.users == null)
          {
              return NotFound();
          }
            var user = await _context.users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(User);
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser( [FromForm] bool isAdmin, [FromForm] string email, [FromForm] string fName, [FromForm] string lName, [FromForm] string pw)
        {
          try
            {
                User user = new User(email, isAdmin, fName, lName, pw, null, null);
                await _usersService.AddAsync(user);
                return CreatedAtAction("GetUser", new { id = user.Id }, user);
            } catch
            {
                throw;
            }
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromForm] Guid id)
        {
            try
            {
                await _usersService.DeleteUser(id);
                
            } catch {
                throw;
            }
            
            return Ok();
        }
    }
}
