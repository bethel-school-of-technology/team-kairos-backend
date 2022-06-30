namespace WebApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.Authorization;using BCrypt.Net;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models;
using System.Linq;
public interface IUserService
{
    AuthenticateResponse Authenticate( AuthenticateRequest model);
    Task<ActionResult<IEnumerable<User>>> GetAll();
    User GetById(int id);
}

public class UserService : IUserService
{
    //users hardcoded for simplicity, store in a db with hashed passwords in production applications
    private List<User> _users = new List<User>
      {
        new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
      };
    private readonly AuthenticationDbContext _context;
    private readonly AppSettings _appSettings;
    
    private IJwtUtils _jwtUtils;

    // AuthenticationDbContext context
    public UserService(AuthenticationDbContext context, IOptions<AppSettings> appSettings)
    {
        _context = context;
        _appSettings = appSettings.Value;
    }

    
         public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _context.User.SingleOrDefault(x => x.Username == model.Username);

        // validate
        if (user == null || !BCrypt.Verify(model.Password, user.Password))
            throw new AppException("Username or password is incorrect");

        // authentication successful so generate jwt token
        var jwtToken = _jwtUtils.GenerateJwtToken(user);

        return new AuthenticateResponse(user, jwtToken);
    }
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
    {
        // return _users;
       var users = await _context.User.ToListAsync();

       return users;

    }

    public User GetById(int id)
    {
        return _context.User.FirstOrDefault(x => x.Id == id);
    }

    // helper methods

    // private string generateJwtToken(User user)
    // {
    //     // generate token that is valid for 7 days
    //     var tokenHandler = new JwtSecurityTokenHandler();
    //     var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
    //     var tokenDescriptor = new SecurityTokenDescriptor
    //     {
    //         Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
    //         Expires = DateTime.UtcNow.AddDays(7),
    //         SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    //     };
    //     var token = tokenHandler.CreateToken(tokenDescriptor);
    //     return tokenHandler.WriteToken(token);
    // }
}
