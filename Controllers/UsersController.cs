using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services;
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;


[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    private readonly AuthenticationDbContext _context;

    public UsersController(AuthenticationDbContext context, IUserService userService)
    {
        _userService = userService;
        _context =context;
    }
    [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
          if (_context.User == null)
          {
              return NotFound();
          }
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

    [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
          if (_context.User == null)
          {
              return Problem("Entity set 'AuthenticationDbContext.User'  is null.");
          }
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] User AuthUser, [FromRoute] AuthenticateRequest model)
    {
        var response = _userService.Authenticate(AuthUser, model);

        if (response == null)
            return null;

        _context.User.Add(AuthUser);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAll", new { id = AuthUser.Id }, AuthUser);
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
        var users = await _context.User.ToListAsync();
        // _userService.GetAll();
        // return Ok(users);
        return users;
    }
}
