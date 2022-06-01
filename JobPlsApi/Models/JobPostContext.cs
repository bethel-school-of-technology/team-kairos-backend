using Microsoft.EntityFrameworkCore;

public class JobPostContext : DbContext
{
    public JobPostContext(DbContextOptions<JobPostContext> options)
        : base(options)
    {
    }

    public DbSet<JobPost> JobPosts { get; set; }
}
