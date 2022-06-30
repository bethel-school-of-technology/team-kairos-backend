namespace WebApi.Entities;

using System.Text.Json.Serialization;
using WebApi.Models;
public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }

    [JsonIgnore]
    public string Password { get; set; }
    public Role Role { get; set; }

    public IEnumerable<JobPost> JobPosts {get; set; }

    public bool IsRecruiter {get; set;}

    
}