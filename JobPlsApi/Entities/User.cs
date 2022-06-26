namespace JobPlsApi.Entities;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using JobPlsApi.Authorization;

public class User
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Username { get; set; }
    public Role Role { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; }
}