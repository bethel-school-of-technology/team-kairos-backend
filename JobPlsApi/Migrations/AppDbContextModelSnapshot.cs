﻿// <auto-generated />
using System;
using JobPlsApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobPlsApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("JobPlsApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Role")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("JobPlsApi.Models.JobPost", b =>
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

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("JobPost", (string)null);
                });

            modelBuilder.Entity("JobPlsApi.Models.JobPost", b =>
                {
                    b.HasOne("JobPlsApi.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}