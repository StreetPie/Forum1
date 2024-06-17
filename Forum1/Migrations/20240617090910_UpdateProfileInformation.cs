using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProfileInformation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forum_Posts_ProfileInformations_ProfileId",
                table: "Forum_Posts");

            migrationBuilder.DropForeignKey(
                name: "FK__ForumPost__Thread",
                table: "Forum_Posts");

            migrationBuilder.DropTable(
                name: "Forum_Threads");

            migrationBuilder.DropIndex(
                name: "IX_Forum_Posts_Thread_ID",
                table: "Forum_Posts");

            migrationBuilder.DropColumn(
                name: "Thread_ID",
                table: "Forum_Posts");

            migrationBuilder.AddForeignKey(
                name: "FK__ForumPost__Profile",
                table: "Forum_Posts",
                column: "ProfileId",
                principalTable: "ProfileInformations",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ForumPost__Profile",
                table: "Forum_Posts");

            migrationBuilder.AddColumn<int>(
                name: "Thread_ID",
                table: "Forum_Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Forum_Threads",
                columns: table => new
                {
                    Thread_ID = table.Column<int>(type: "int", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ForumThread__8C4D3BBBA4A0D430", x => x.Thread_ID);
                    table.ForeignKey(
                        name: "FK__ForumThread__User",
                        column: x => x.User_ID,
                        principalTable: "User_Accounts",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Forum_Posts_Thread_ID",
                table: "Forum_Posts",
                column: "Thread_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_Threads_User_ID",
                table: "Forum_Threads",
                column: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Forum_Posts_ProfileInformations_ProfileId",
                table: "Forum_Posts",
                column: "ProfileId",
                principalTable: "ProfileInformations",
                principalColumn: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK__ForumPost__Thread",
                table: "Forum_Posts",
                column: "Thread_ID",
                principalTable: "Forum_Threads",
                principalColumn: "Thread_ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
