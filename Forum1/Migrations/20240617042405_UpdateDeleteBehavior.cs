using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Forum1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeleteBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Role_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Role_ID);
                });

            migrationBuilder.CreateTable(
                name: "Science_Schedules",
                columns: table => new
                {
                    Schedule_ID = table.Column<int>(type: "int", nullable: false),
                    Day_of_Week = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Start_Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    End_Time = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ScienceSchedule__8C4D3BBBA4A0D430", x => x.Schedule_ID);
                });

            migrationBuilder.CreateTable(
                name: "Role_Permissions",
                columns: table => new
                {
                    Permission_ID = table.Column<int>(type: "int", nullable: false),
                    Role_ID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role_Per__89B744E583F451AB", x => x.Permission_ID);
                    table.ForeignKey(
                        name: "FK__Role_Perm__Role___2F10007B",
                        column: x => x.Role_ID,
                        principalTable: "Roles",
                        principalColumn: "Role_ID");
                });

            migrationBuilder.CreateTable(
                name: "User_Accounts",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(900)", unicode: false, nullable: false),
                    FullName = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Password = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    LastLogin = table.Column<DateOnly>(type: "date", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Role_ID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Accounts", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_User_Accounts_Roles_Role_ID",
                        column: x => x.Role_ID,
                        principalTable: "Roles",
                        principalColumn: "Role_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoleUserRole",
                columns: table => new
                {
                    AccountIdRoleId = table.Column<int>(type: "int", nullable: false),
                    UserRolesRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleUserRole", x => new { x.AccountIdRoleId, x.UserRolesRoleId });
                    table.ForeignKey(
                        name: "FK_UserRoleUserRole_Roles_AccountIdRoleId",
                        column: x => x.AccountIdRoleId,
                        principalTable: "Roles",
                        principalColumn: "Role_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoleUserRole_Roles_UserRolesRoleId",
                        column: x => x.UserRolesRoleId,
                        principalTable: "Roles",
                        principalColumn: "Role_ID");
                });

            migrationBuilder.CreateTable(
                name: "Access_Log",
                columns: table => new
                {
                    Log_ID = table.Column<int>(type: "int", nullable: false),
                    Access_Time = table.Column<DateTime>(type: "datetime", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Action_Performed = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Access_L__2D26E7AE3FD807B7", x => x.Log_ID);
                    table.ForeignKey(
                        name: "FK__Access_Log__Account__38996AB5",
                        column: x => x.User_ID,
                        principalTable: "User_Accounts",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Access_Restrictions",
                columns: table => new
                {
                    Restriction_ID = table.Column<int>(type: "int", nullable: false),
                    Employee_ID = table.Column<int>(type: "int", nullable: true),
                    Access_From = table.Column<DateOnly>(type: "date", nullable: true),
                    Access_To = table.Column<DateOnly>(type: "date", nullable: true),
                    IP = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Access_R__1D4F7CD6F6019110", x => x.Restriction_ID);
                    table.ForeignKey(
                        name: "FK__Access_Re__Use__267ABA7A",
                        column: x => x.Employee_ID,
                        principalTable: "User_Accounts",
                        principalColumn: "User_ID");
                });

            migrationBuilder.CreateTable(
                name: "Contact_Information",
                columns: table => new
                {
                    Contact_ID = table.Column<int>(type: "int", nullable: false),
                    Employee_ID = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Email_Address = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Contact___82ACC1CD23B85382", x => x.Contact_ID);
                    table.ForeignKey(
                        name: "FK__Contact_I__Emplo__3E52440B",
                        column: x => x.Employee_ID,
                        principalTable: "User_Accounts",
                        principalColumn: "User_ID");
                });

         

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Notification_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Account_ID = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Notification_ID);
                    table.ForeignKey(
                        name: "FK_Notifications_User_Accounts_Account_ID",
                        column: x => x.Account_ID,
                        principalTable: "User_Accounts",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_History",
                columns: table => new
                {
                    History_ID = table.Column<int>(type: "int", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Action = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__UserHistory__8C4D3BBBA4A0D430", x => x.History_ID);
                    table.ForeignKey(
                        name: "FK_User_History_User_Accounts_User_ID",
                        column: x => x.User_ID,
                        principalTable: "User_Accounts",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAccountUserRole",
                columns: table => new
                {
                    RolesRoleId = table.Column<int>(type: "int", nullable: false),
                    UserAccountAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccountUserRole", x => new { x.RolesRoleId, x.UserAccountAccountId });
                    table.ForeignKey(
                        name: "FK_UserAccountUserRole_Roles_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalTable: "Roles",
                        principalColumn: "Role_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAccountUserRole_User_Accounts_UserAccountAccountId",
                        column: x => x.UserAccountAccountId,
                        principalTable: "User_Accounts",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Forum_Posts",
                columns: table => new
                {
                    Post_ID = table.Column<int>(type: "int", nullable: false),
                    Thread_ID = table.Column<int>(type: "int", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    Created_At = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ForumPost__8C4D3BBBA4A0D430", x => x.Post_ID);
                    table.ForeignKey(
                        name: "FK__ForumPost__Thread",
                        column: x => x.Thread_ID,
                        principalTable: "Forum_Threads",
                        principalColumn: "Thread_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ForumPost__User",
                        column: x => x.User_ID,
                        principalTable: "User_Accounts",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Forum_Comments",
                columns: table => new
                {
                    Comment_ID = table.Column<int>(type: "int", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Post_ID = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ForumComment__8C4D3BBBA4A0D430", x => x.Comment_ID);
                    table.ForeignKey(
                        name: "FK__ForumComment__Post",
                        column: x => x.Post_ID,
                        principalTable: "Forum_Posts",
                        principalColumn: "Post_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__ForumComment__User",
                        column: x => x.User_ID,
                        principalTable: "User_Accounts",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Access_Log_User_ID",
                table: "Access_Log",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Access_Restrictions_Employee_ID",
                table: "Access_Restrictions",
                column: "Employee_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Information_Employee_ID",
                table: "Contact_Information",
                column: "Employee_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_Comments_Post_ID",
                table: "Forum_Comments",
                column: "Post_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_Comments_User_ID",
                table: "Forum_Comments",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_Posts_Thread_ID",
                table: "Forum_Posts",
                column: "Thread_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_Posts_User_ID",
                table: "Forum_Posts",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Forum_Threads_User_ID",
                table: "Forum_Threads",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_Account_ID",
                table: "Notifications",
                column: "Account_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Role_Permissions_Role_ID",
                table: "Role_Permissions",
                column: "Role_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Accounts_Email",
                table: "User_Accounts",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Accounts_Role_ID",
                table: "User_Accounts",
                column: "Role_ID");

            migrationBuilder.CreateIndex(
                name: "IX_User_History_User_ID",
                table: "User_History",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAccountUserRole_UserAccountAccountId",
                table: "UserAccountUserRole",
                column: "UserAccountAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleUserRole_UserRolesRoleId",
                table: "UserRoleUserRole",
                column: "UserRolesRoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Access_Log");

            migrationBuilder.DropTable(
                name: "Access_Restrictions");

            migrationBuilder.DropTable(
                name: "Contact_Information");

            migrationBuilder.DropTable(
                name: "Forum_Comments");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Role_Permissions");

            migrationBuilder.DropTable(
                name: "Science_Schedules");

            migrationBuilder.DropTable(
                name: "User_History");

            migrationBuilder.DropTable(
                name: "UserAccountUserRole");

            migrationBuilder.DropTable(
                name: "UserRoleUserRole");

            migrationBuilder.DropTable(
                name: "Forum_Posts");

            migrationBuilder.DropTable(
                name: "Forum_Threads");

            migrationBuilder.DropTable(
                name: "User_Accounts");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
