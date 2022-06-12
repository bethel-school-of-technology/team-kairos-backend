using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPlsApi.Migrations
{
    public partial class DataMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "JobPost",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    JobCompany = table.Column<string>(type: "TEXT", nullable: true),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: true),
                    JobDescription = table.Column<string>(type: "TEXT", nullable: true),
                    JobLocation = table.Column<string>(type: "TEXT", nullable: true),
                    MinPayRange = table.Column<long>(type: "INTEGER", nullable: false),
                    MaxPayRange = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobPost", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobseeker",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 60, nullable: true),
                    UserName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "TEXT", unicode: false, maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Recruiter",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 60, nullable: true),
                    UserName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "TEXT", unicode: false, maxLength: 20, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobPost");

            migrationBuilder.DropTable(
                name: "Jobseeker");

            migrationBuilder.DropTable(
                name: "Recruiter");
        }
    }
}
