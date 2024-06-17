using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum1.Migrations
{
    /// <inheritdoc />
    public partial class CreateProfileInformationsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forum_Posts_ProfileInformations_ProfileId",
                table: "Forum_Posts");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ProfileInformations");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "ProfileInformations");

            migrationBuilder.AddColumn<string>(
                name: "ProfileName",
                table: "ProfileInformations",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "Forum_Posts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Forum_Posts_ProfileInformations_ProfileId",
                table: "Forum_Posts",
                column: "ProfileId",
                principalTable: "ProfileInformations",
                principalColumn: "ProfileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Forum_Posts_ProfileInformations_ProfileId",
                table: "Forum_Posts");

            migrationBuilder.DropColumn(
                name: "ProfileName",
                table: "ProfileInformations");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ProfileInformations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ProfileInformations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "Forum_Posts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Forum_Posts_ProfileInformations_ProfileId",
                table: "Forum_Posts",
                column: "ProfileId",
                principalTable: "ProfileInformations",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
