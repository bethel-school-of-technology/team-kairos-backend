using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;



public class AppUser : IdentityUser
{
    public string? GuestUser { get; set; }
    public IEnumerable<JobPost>? JobPosts { get; set; }
}
