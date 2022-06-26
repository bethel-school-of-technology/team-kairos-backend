using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobPlsApi.Migrations
{
    public partial class Initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "PasswordHash");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "User",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "JobPost",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobPost_UserId",
                table: "JobPost",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobPost_User_UserId",
                table: "JobPost",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobPost_User_UserId",
                table: "JobPost");

            migrationBuilder.DropIndex(
                name: "IX_JobPost_UserId",
                table: "JobPost");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "JobPost");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "User",
                newName: "Password");
        }
    }
}
