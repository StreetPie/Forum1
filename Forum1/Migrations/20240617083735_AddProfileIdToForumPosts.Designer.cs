﻿// <auto-generated />
using System;
using Forum1.Models.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Forum1.Migrations
{
    [DbContext(typeof(ForumContext))]
    [Migration("20240617083735_AddProfileIdToForumPosts")]
    partial class AddProfileIdToForumPosts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Forum1.Models.DBModels.AccessLog", b =>
                {
                    b.Property<int>("LogId")
                        .HasColumnType("int")
                        .HasColumnName("Log_ID");

                    b.Property<DateTime>("AccessTime")
                        .HasColumnType("datetime")
                        .HasColumnName("Access_Time");

                    b.Property<int>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.Property<string>("ActionPerformed")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Action_Performed");

                    b.HasKey("LogId")
                        .HasName("PK__Access_L__2D26E7AE3FD807B7");

                    b.HasIndex("AccountId");

                    b.ToTable("Access_Log", (string)null);
                });

            modelBuilder.Entity("Forum1.Models.DBModels.AccessRestriction", b =>
                {
                    b.Property<int>("RestrictionId")
                        .HasColumnType("int")
                        .HasColumnName("Restriction_ID");

                    b.Property<DateOnly?>("AccessFrom")
                        .HasColumnType("date")
                        .HasColumnName("Access_From");

                    b.Property<DateOnly?>("AccessTo")
                        .HasColumnType("date")
                        .HasColumnName("Access_To");

                    b.Property<int?>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("Employee_ID");

                    b.Property<string>("Ip")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("IP");

                    b.HasKey("RestrictionId")
                        .HasName("PK__Access_R__1D4F7CD6F6019110");

                    b.HasIndex("AccountId");

                    b.ToTable("Access_Restrictions", (string)null);
                });

            modelBuilder.Entity("Forum1.Models.DBModels.ContactInformation", b =>
                {
                    b.Property<int>("ContactId")
                        .HasColumnType("int")
                        .HasColumnName("Contact_ID");

                    b.Property<int?>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("Employee_ID");

                    b.Property<string>("EmailAddress")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Email_Address");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("ContactId")
                        .HasName("PK__Contact___82ACC1CD23B85382");

                    b.HasIndex("AccountId");

                    b.ToTable("Contact_Information", (string)null);
                });

            modelBuilder.Entity("Forum1.Models.DBModels.ForumComment", b =>
                {
                    b.Property<int>("CommentId")
                        .HasColumnType("int")
                        .HasColumnName("Comment_ID");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("Content");

                    b.Property<int>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("Post_ID");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2")
                        .HasColumnName("Timestamp");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.HasKey("CommentId")
                        .HasName("PK__ForumComment__8C4D3BBBA4A0D430");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Forum_Comments", (string)null);
                });

            modelBuilder.Entity("Forum1.Models.DBModels.ForumPost", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int")
                        .HasColumnName("Post_ID");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("Content");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime")
                        .HasColumnName("Created_At");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.Property<int>("ThreadId")
                        .HasColumnType("int")
                        .HasColumnName("Thread_ID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.HasKey("PostId")
                        .HasName("PK__ForumPost__8C4D3BBBA4A0D430");

                    b.HasIndex("ProfileId");

                    b.HasIndex("ThreadId");

                    b.HasIndex("UserId");

                    b.ToTable("Forum_Posts", (string)null);
                });

            modelBuilder.Entity("Forum1.Models.DBModels.ForumThread", b =>
                {
                    b.Property<int>("ThreadId")
                        .HasColumnType("int")
                        .HasColumnName("Thread_ID");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasColumnName("Created_At");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Title");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.HasKey("ThreadId")
                        .HasName("PK__ForumThread__8C4D3BBBA4A0D430");

                    b.HasIndex("UserId");

                    b.ToTable("Forum_Threads", (string)null);
                });

            modelBuilder.Entity("Forum1.Models.DBModels.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Notification_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int")
                        .HasColumnName("Account_ID");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(false)
                        .HasColumnType("varchar(1000)");

                    b.HasKey("NotificationId");

                    b.HasIndex("AccountId");

                    b.ToTable("Notifications", (string)null);
                });

            modelBuilder.Entity("Forum1.Models.DBModels.ProfileInformation", b =>
                {
                    b.Property<int>("ProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfileId"));

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.Property<string>("ContactInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ProfileId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("ProfileInformations");
                });

            modelBuilder.Entity("Forum1.Models.DBModels.RolePermission", b =>
                {
                    b.Property<int>("PermissionId")
                        .HasColumnType("int")
                        .HasColumnName("Permission_ID");

                    b.Property<string>("Name")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("Role_ID");

                    b.HasKey("PermissionId")
                        .HasName("PK__Role_Per__89B744E583F451AB");

                    b.HasIndex("RoleId");

                    b.ToTable("Role_Permissions", (string)null);
                });

            modelBuilder.Entity("Forum1.Models.DBModels.ScienceSchedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .HasColumnType("int")
                        .HasColumnName("Schedule_ID");

                    b.Property<string>("DayOfWeek")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Day_of_Week");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time")
                        .HasColumnName("End_Time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time")
                        .HasColumnName("Start_Time");

                    b.HasKey("ScheduleId")
                        .HasName("PK__ScienceSchedule__8C4D3BBBA4A0D430");

                    b.ToTable("Science_Schedules", (string)null);
                });

            modelBuilder.Entity("Forum1.Models.DBModels.UserAccount", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(900)");

                    b.Property<string>("FullName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<DateOnly>("LastLogin")
                        .HasColumnType("date");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("Role_ID");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("AccountId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("User_Accounts", (string)null);
                });

            modelBuilder.Entity("Forum1.Models.DBModels.UserHistory", b =>
                {
                    b.Property<int>("HistoryId")
                        .HasColumnType("int")
                        .HasColumnName("History_ID");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("Action");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2")
                        .HasColumnName("Timestamp");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.HasKey("HistoryId")
                        .HasName("PK__UserHistory__8C4D3BBBA4A0D430");

                    b.HasIndex("UserId");

                    b.ToTable("User_History", (string)null);
                });

            modelBuilder.Entity("Forum1.Models.DBModels.UserRole", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Role_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("RoleId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("UserAccountUserRole", b =>
                {
                    b.Property<int>("RolesRoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserAccountAccountId")
                        .HasColumnType("int");

                    b.HasKey("RolesRoleId", "UserAccountAccountId");

                    b.HasIndex("UserAccountAccountId");

                    b.ToTable("UserAccountUserRole");
                });

            modelBuilder.Entity("UserRoleUserRole", b =>
                {
                    b.Property<int>("AccountIdRoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserRolesRoleId")
                        .HasColumnType("int");

                    b.HasKey("AccountIdRoleId", "UserRolesRoleId");

                    b.HasIndex("UserRolesRoleId");

                    b.ToTable("UserRoleUserRole");
                });

            modelBuilder.Entity("Forum1.Models.DBModels.AccessLog", b =>
                {
                    b.HasOne("Forum1.Models.DBModels.UserAccount", "Account")
                        .WithMany("AccessLogs")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Access_Log__Account__38996AB5");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Forum1.Models.DBModels.AccessRestriction", b =>
                {
                    b.HasOne("Forum1.Models.DBModels.UserAccount", "UserAccount")
                        .WithMany("AccessRestrictions")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK__Access_Re__Use__267ABA7A");

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Forum1.Models.DBModels.ContactInformation", b =>
                {
                    b.HasOne("Forum1.Models.DBModels.UserAccount", "UserAccount")
                        .WithMany("ContactInformations")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("FK__Contact_I__Emplo__3E52440B");

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Forum1.Models.DBModels.ForumComment", b =>
                {
                    b.HasOne("Forum1.Models.DBModels.ForumPost", "Post")
                        .WithMany("ForumComments")
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__ForumComment__Post");

                    b.HasOne("Forum1.Models.DBModels.UserAccount", "User")
                        .WithMany("ForumComments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__ForumComment__User");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Forum1.Models.DBModels.ForumPost", b =>
                {
                    b.HasOne("Forum1.Models.DBModels.ProfileInformation", "Profile")
                        .WithMany("ForumPosts")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forum1.Models.DBModels.ForumThread", "Thread")
                        .WithMany("ForumPosts")
                        .HasForeignKey("ThreadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK__ForumPost__Thread");

                    b.HasOne("Forum1.Models.DBModels.UserAccount", "User")
                        .WithMany("ForumPosts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK__ForumPost__User");

                    b.Navigation("Profile");

                    b.Navigation("Thread");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Forum1.Models.DBModels.ForumThread", b =>
                {
                    b.HasOne("Forum1.Models.DBModels.UserAccount", "User")
                        .WithMany("ForumThreads")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__ForumThread__User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Forum1.Models.DBModels.Notification", b =>
                {
                    b.HasOne("Forum1.Models.DBModels.UserAccount", "UserAccount")
                        .WithMany("Notifications")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserAccount");
                });

            modelBuilder.Entity("Forum1.Models.DBModels.ProfileInformation", b =>
                {
                    b.HasOne("Forum1.Models.DBModels.UserAccount", "User")
                        .WithOne("Profile")
                        .HasForeignKey("Forum1.Models.DBModels.ProfileInformation", "UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Forum1.Models.DBModels.RolePermission", b =>
                {
                    b.HasOne("Forum1.Models.DBModels.UserRole", "Role")
                        .WithMany("RolePermissions")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK__Role_Perm__Role___2F10007B");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Forum1.Models.DBModels.UserAccount", b =>
                {
                    b.HasOne("Forum1.Models.DBModels.UserRole", "Role")
                        .WithMany("UserAccounts")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Forum1.Models.DBModels.UserHistory", b =>
                {
                    b.HasOne("Forum1.Models.DBModels.UserAccount", "User")
                        .WithMany("UserLoginHistories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserAccountUserRole", b =>
                {
                    b.HasOne("Forum1.Models.DBModels.UserRole", null)
                        .WithMany()
                        .HasForeignKey("RolesRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forum1.Models.DBModels.UserAccount", null)
                        .WithMany()
                        .HasForeignKey("UserAccountAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("UserRoleUserRole", b =>
                {
                    b.HasOne("Forum1.Models.DBModels.UserRole", null)
                        .WithMany()
                        .HasForeignKey("AccountIdRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Forum1.Models.DBModels.UserRole", null)
                        .WithMany()
                        .HasForeignKey("UserRolesRoleId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Forum1.Models.DBModels.ForumPost", b =>
                {
                    b.Navigation("ForumComments");
                });

            modelBuilder.Entity("Forum1.Models.DBModels.ForumThread", b =>
                {
                    b.Navigation("ForumPosts");
                });

            modelBuilder.Entity("Forum1.Models.DBModels.ProfileInformation", b =>
                {
                    b.Navigation("ForumPosts");
                });

            modelBuilder.Entity("Forum1.Models.DBModels.UserAccount", b =>
                {
                    b.Navigation("AccessLogs");

                    b.Navigation("AccessRestrictions");

                    b.Navigation("ContactInformations");

                    b.Navigation("ForumComments");

                    b.Navigation("ForumPosts");

                    b.Navigation("ForumThreads");

                    b.Navigation("Notifications");

                    b.Navigation("Profile")
                        .IsRequired();

                    b.Navigation("UserLoginHistories");
                });

            modelBuilder.Entity("Forum1.Models.DBModels.UserRole", b =>
                {
                    b.Navigation("RolePermissions");

                    b.Navigation("UserAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}
