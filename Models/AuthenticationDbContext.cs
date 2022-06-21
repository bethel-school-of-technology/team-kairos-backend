

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities;


namespace WebApi.Models {

public class AuthenticationDbContext : DbContext {
     
     public AuthenticationDbContext(DbContextOptions<AuthenticationDbContext> options)
            : base(options)
        {
        }
     
     public DbSet<User> User { get; set; }
     

}
}