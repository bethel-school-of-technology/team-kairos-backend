using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using JobPlsApi.Models;

namespace JobPlsApi.Data
{
    public partial class JobPlsApiContext : DbContext
    {
        public JobPlsApiContext()
        {
        }

        public JobPlsApiContext(DbContextOptions<JobPlsApiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JobPost> JobPosts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobPost>(entity =>
            {
                entity.ToTable("JobPost");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
