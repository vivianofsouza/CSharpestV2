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
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

        // GET /api/Users/Login
        [HttpGet("Login")]
        public async Task<ActionResult<Guid>> Login(string email, string password)
        {
            try
            {
                await _usersService.Login(email, password);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

        // GET: api/Users/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
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

            return user;
        }

        // PUT: api/Users/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(Guid id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.users == null)
          {
              return Problem("Entity set 'StoreContext.users'  is null.");
          }
            _context.users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/Users/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            try
            {
                await _usersService.DeleteUser(id);
                return NoContent();
            } catch {
                throw;
            }
        }

        private bool UserExists(Guid id)
        {
            return (_context.users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
