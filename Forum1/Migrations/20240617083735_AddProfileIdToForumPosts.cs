using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum1.Migrations
{
    /// <inheritdoc />
    public partial class AddProfileIdToForumPosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProfileInformations_UserId",
                table: "ProfileInformations");

            migrationBuilder.RenameColumn(
                name: "ProfileInformatin",
                table: "ProfileInformations",
                newName: "LastName");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "ProfileInformations",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ProfileInformations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Forum_Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileInformations",
                table: "ProfileInformations",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileInformations_UserId",
                table: "ProfileInformations",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_Posts_ProfileId",
                table: "Forum_Posts",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Forum_Posts_ProfileInformations_ProfileId",
                table: "Forum_Posts",
                column: "ProfileId",
                principalTable: "ProfileInformations",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forum_Posts_ProfileInformations_ProfileId",
                table: "Forum_Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileInformations",
                table: "ProfileInformations");

            migrationBuilder.DropIndex(
                name: "IX_ProfileInformations_UserId",
                table: "ProfileInformations");

            migrationBuilder.DropIndex(
                name: "IX_Forum_Posts_ProfileId",
                table: "Forum_Posts");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "ProfileInformations");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ProfileInformations");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Forum_Posts");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "ProfileInformations",
                newName: "ProfileInformatin");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileInformations_UserId",
                table: "ProfileInformations",
                column: "UserId");
        }
    }
}
