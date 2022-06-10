using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using JobPlsApi.Models;

namespace JobPlsApi.Data
{
    public partial class JobPostContext : DbContext
    {
        public JobPostContext()
        {
        }

        public JobPostContext(DbContextOptions<JobPostContext> options)
            : base(options)
        {
        }

        public virtual DbSet<JobPost> JobPosts { get; set; } = null!;
        public virtual DbSet<Company> Company { get; set; } = null!;
        public virtual DbSet<JobApplicationPortal> JobApplicationPortal { get; set; } = null!;
        public virtual DbSet<JobDescription> JobDescription { get; set; } = null!;
        public virtual DbSet<ListJobPosts> ListJobPosts { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<JobPost>(entity =>
            {
                entity.ToTable("JobPost");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");
            });

            modelBuilder.Entity<JobApplicationPortal>(entity =>
            {
                entity.ToTable("JobApplicationPortal");
            });

            modelBuilder.Entity<JobDescription>(entity =>
            {
                entity.ToTable("JobDescription");
            });

            modelBuilder.Entity<ListJobPosts>(entity =>
            {
                entity.ToTable("ListJobPosts");
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}