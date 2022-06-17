// namespace JobPlsApi.Controllers;

// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using JobPlsApi.Models;
// using JobPlsApi.Data;
// using Microsoft.Extensions.Options;
// using JobPlsApi.Helpers;
// using JobPlsApi.Services;
// using System.IdentityModel.Tokens.Jwt;
// using System.Text;
// using Microsoft.IdentityModel.Tokens;

//     [Route("api/[controller]")]
//     [ApiController]
//     public class UsersController : ControllerBase
//     {
//         private IUserService _userService;

//         public UsersController(IUserService userService)
//         {
//             _userService = userService;
//         }

//         [HttpPost("authenticate")]
//         public IActionResult Authenticate(AuthenticateRequest model)
//         {
//             var response = _userService.Authenticate(model);

//             if (response == null)
//                 return BadRequest(new { message = "Username or password is incorrect" });

//             return Ok(response);
//         }

//         [Authorize]
//         [HttpGet]
//         public IActionResult GetAll()
//         {
//             var users = _userService.GetAll();
//             return Ok(users);
//         }
//     }



using Microsoft.AspNetCore.Mvc;
using JobPlsApi.Helpers;
using JobPlsApi.Models;
using JobPlsApi.Services;

namespace JobPlsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        if (response == null)
            return BadRequest(new { message = "Username or password is incorrect" });

        return Ok(response);
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
}
