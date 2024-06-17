using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum1.Migrations
{
    /// <inheritdoc />
    public partial class DateBirth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "User_Accounts",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProfileInformations",
                columns: table => new
                {
                    ProfileInformatin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactInformation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ProfileInformations_User_Accounts_UserId",
                        column: x => x.UserId,
                        principalTable: "User_Accounts",
                        principalColumn: "User_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProfileInformations_UserId",
                table: "ProfileInformations",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfileInformations");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "User_Accounts");
        }
    }
}
