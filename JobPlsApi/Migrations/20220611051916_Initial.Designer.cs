﻿// <auto-generated />
using System;
using JobPlsApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobPlsApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220611051916_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

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

                    b.HasKey("Id");

                    b.ToTable("JobPost", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
