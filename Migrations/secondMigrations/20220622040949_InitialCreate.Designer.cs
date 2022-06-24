﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Models;

#nullable disable

namespace WebApi.Migrations.secondMigrations
{
    [DbContext(typeof(AuthenticationDbContext))]
    [Migration("20220622040949_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("WebApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsRecruiter")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.Property<int?>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Users", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("WebApi.Models.JobPost", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("JobCompany")
                        .HasColumnType("TEXT");

                    b.Property<string>("JobDescription")
                        .HasColumnType("TEXT");

                    b.Property<string>("JobLocation")
                        .HasColumnType("TEXT");

                    b.Property<string>("JobTitle")
                        .HasColumnType("TEXT");

                    b.Property<long?>("MaxPayRange")
                        .HasColumnType("INTEGER");

                    b.Property<long>("MinPayRange")
                        .HasColumnType("INTEGER");

                    b.Property<string>("URLToJobApp")
                        .HasColumnType("TEXT");

                    b.Property<int?>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("JobPost");
                });

            modelBuilder.Entity("WebApi.Models.Recruiter", b =>
                {
                    b.HasBaseType("WebApi.Entities.User");

                    b.Property<string>("Organization")
                        .HasColumnType("TEXT");

                    b.Property<string>("jobTitle")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Recruiter");
                });

            modelBuilder.Entity("WebApi.Entities.User", b =>
                {
                    b.HasOne("WebApi.Models.Recruiter", "user")
                        .WithMany()
                        .HasForeignKey("userId");

                    b.Navigation("user");
                });

            modelBuilder.Entity("WebApi.Models.JobPost", b =>
                {
                    b.HasOne("WebApi.Models.Recruiter", "user")
                        .WithMany("JobPosts")
                        .HasForeignKey("userId");

                    b.Navigation("user");
                });

            modelBuilder.Entity("WebApi.Models.Recruiter", b =>
                {
                    b.Navigation("JobPosts");
                });
#pragma warning restore 612, 618
        }
    }
}
