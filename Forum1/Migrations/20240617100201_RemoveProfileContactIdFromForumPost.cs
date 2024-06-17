using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum1.Migrations
{
    /// <inheritdoc />
    public partial class RemoveProfileContactIdFromForumPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Contact_I__Emplo__3E52440B",
                table: "Contact_Information");

            migrationBuilder.DropForeignKey(
                name: "FK__ForumPost__Profile",
                table: "Forum_Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileInformations",
                table: "ProfileInformations");

            migrationBuilder.DropIndex(
                name: "IX_Forum_Posts_ProfileId",
                table: "Forum_Posts");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "ProfileInformations");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "Forum_Posts");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "ProfileInformations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProfileContactId",
                table: "Forum_Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileInformations",
                table: "ProfileInformations",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_Posts_ProfileContactId",
                table: "Forum_Posts",
                column: "ProfileContactId");

            migrationBuilder.AddForeignKey(
                name: "FK__Contact_I___3E52440B",
                table: "Contact_Information",
                column: "Employee_ID",
                principalTable: "User_Accounts",
                principalColumn: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Forum_Posts_ProfileInformations_ProfileContactId",
                table: "Forum_Posts",
                column: "ProfileContactId",
                principalTable: "ProfileInformations",
                principalColumn: "ContactId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Contact_I___3E52440B",
                table: "Contact_Information");

            migrationBuilder.DropForeignKey(
                name: "FK_Forum_Posts_ProfileInformations_ProfileContactId",
                table: "Forum_Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfileInformations",
                table: "ProfileInformations");

            migrationBuilder.DropIndex(
                name: "IX_Forum_Posts_ProfileContactId",
                table: "Forum_Posts");

            migrationBuilder.DropColumn(
                name: "ProfileContactId",
                table: "Forum_Posts");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "ProfileInformations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "ProfileInformations",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProfileId",
                table: "Forum_Posts",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfileInformations",
                table: "ProfileInformations",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_Posts_ProfileId",
                table: "Forum_Posts",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK__Contact_I__Emplo__3E52440B",
                table: "Contact_Information",
                column: "Employee_ID",
                principalTable: "User_Accounts",
                principalColumn: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK__ForumPost__Profile",
                table: "Forum_Posts",
                column: "ProfileId",
                principalTable: "ProfileInformations",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
