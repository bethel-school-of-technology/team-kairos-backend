using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services;
using WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi.Authorization;

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

 [AllowAnonymous]
    [HttpPost("[action]")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);
        return Ok(response);
    }

    [Authorize(Role.Admin)]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

[HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        // only admins can access other user records
        var currentUser = (User)HttpContext.Items["User"];
        if (id != currentUser.Id && currentUser.Role != Role.Admin)
            return Unauthorized(new { message = "Unauthorized" });

        var user =  _userService.GetById(id);
        return Ok(user);
    }
}
