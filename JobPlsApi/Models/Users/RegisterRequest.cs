namespace JobPlsApi.Models.Users;

using System.ComponentModel.DataAnnotations;
using JobPlsApi.Entities;

public class RegisterRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    // [Required]
    public string Username { get; set; }

    // [Required]
    public Role Role { get; set; }
      
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}