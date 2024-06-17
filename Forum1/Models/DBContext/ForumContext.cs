using Forum1.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace Forum1.Models.DBContext
{
    public partial class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<UserRole> Roles { get; set; }
        public virtual DbSet<AccessLog> AccessLogs { get; set; }
        public virtual DbSet<AccessRestriction> AccessRestrictions { get; set; }
        public virtual DbSet<ContactInformation> ContactInformations { get; set; }
        public virtual DbSet<ForumComment> ForumComments { get; set; }
        public virtual DbSet<ScienceSchedule> ScienceSchedules { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }
        public virtual DbSet<UserHistory> UserHistories { get; set; }
        public virtual DbSet<ForumPost> ForumPosts { get; set; }
        public virtual DbSet<RolePermission> RolePermissions { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.HasKey(e => e.AccountId);
                entity.ToTable("User_Accounts");
                entity.Property(e => e.AccountId).HasColumnName("User_ID");
                entity.Property(e => e.Login).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Email).IsRequired().IsUnicode(false);
                entity.Property(e => e.Password).IsRequired().HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.FullName).HasMaxLength(255).IsUnicode(false);
                entity.Property(e => e.LastLogin).HasColumnType("date");
                entity.Property(e => e.PhoneNumber).IsUnicode(false);
                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
                entity.Property(e => e.Status).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                entity.HasOne(d => d.Role)
                    .WithMany(r => r.UserAccounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => e.Email).IsUnique();

                entity.HasMany(e => e.Notifications)
                    .WithOne(n => n.UserAccount)
                    .HasForeignKey(n => n.AccountId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.NotificationId);
                entity.ToTable("Notifications");
                entity.Property(e => e.NotificationId).HasColumnName("Notification_ID");
                entity.Property(e => e.AccountId).HasColumnName("Account_ID");
                entity.Property(e => e.Message).IsRequired().HasMaxLength(1000).IsUnicode(false);
                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.HasOne(n => n.UserAccount)
                    .WithMany(u => u.Notifications)
                    .HasForeignKey(n => n.AccountId)
                    .OnDelete(DeleteBehavior.Cascade);
            });




  



            base.OnModelCreating(modelBuilder);
        


        modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId);
                entity.ToTable("Roles");
                entity.Property(e => e.RoleId).HasColumnName("Role_ID");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255).IsUnicode(false);

                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<AccessLog>(entity =>
            {
                entity.HasKey(e => e.LogId).HasName("PK__Access_L__2D26E7AE3FD807B7");
                entity.ToTable("Access_Log");
                entity.Property(e => e.LogId).ValueGeneratedNever().HasColumnName("Log_ID");
                entity.Property(e => e.AccessTime).HasColumnType("datetime").HasColumnName("Access_Time");
                entity.Property(e => e.AccountId).HasColumnName("User_ID");
                entity.Property(e => e.ActionPerformed).HasMaxLength(255).IsUnicode(false).HasColumnName("Action_Performed");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccessLogs)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Access_Log__Account__38996AB5");
            });

            //modelBuilder.Entity<ProfileInformation>(entity =>
            //{
            //    entity.HasKey(e => e.ContactId); // Установка первичного ключа как ContactId
            //    entity.ToTable("ProfileInformations"); // Имя таблицы
            //    entity.Property(e => e.ProfileName).IsRequired().HasMaxLength(255);

            //});
            modelBuilder.Entity<ForumPost>(entity =>
            {
                entity.HasKey(e => e.PostId).HasName("PK__ForumPost__8C4D3BBBA4A0D430");
                entity.ToTable("Forum_Posts");
                entity.Property(e => e.PostId).ValueGeneratedNever().HasColumnName("Post_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");
                entity.Property(e => e.Content).HasMaxLength(1000).IsUnicode(false).HasColumnName("Content");
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasColumnName("Created_At");



                entity.HasOne(d => d.User)
                    .WithMany(p => p.ForumPosts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict) // Указание поведения при удалении
                    .HasConstraintName("FK__ForumPost__User"); 
            });

            modelBuilder.Entity<AccessRestriction>(entity =>
            {
                entity.HasKey(e => e.RestrictionId).HasName("PK__Access_R__1D4F7CD6F6019110");

                entity.ToTable("Access_Restrictions");

                entity.Property(e => e.RestrictionId)
                    .ValueGeneratedNever()
                    .HasColumnName("Restriction_ID");
                entity.Property(e => e.AccessFrom).HasColumnName("Access_From");
                entity.Property(e => e.AccessTo).HasColumnName("Access_To");
                entity.Property(e => e.AccountId).HasColumnName("Employee_ID");
                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.HasOne(d => d.UserAccount).WithMany(p => p.AccessRestrictions)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Access_Re__Use__267ABA7A");
            });

            modelBuilder.Entity<ContactInformation>(entity =>
            {
                entity.HasKey(e => e.ContactId).HasName("PK__Contact___82ACC1CD23B85382");

                entity.ToTable("Contact_Information");

                entity.Property(e => e.ContactId)
                    .ValueGeneratedNever()
                    .HasColumnName("Contact_ID");
                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Email_Address");
                entity.Property(e => e.AccountId).HasColumnName("Employee_ID");
                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserAccount).WithMany(p => p.ContactInformations)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Contact_I___3E52440B");
            });

            modelBuilder.Entity<ScienceSchedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId).HasName("PK__ScienceSchedule__8C4D3BBBA4A0D430");
                entity.ToTable("Science_Schedules");
                entity.Property(e => e.ScheduleId).ValueGeneratedNever().HasColumnName("Schedule_ID");
                entity.Property(e => e.DayOfWeek).HasMaxLength(20).IsUnicode(false).HasColumnName("Day_of_Week");
                entity.Property(e => e.StartTime).HasColumnName("Start_Time");
                entity.Property(e => e.EndTime).HasColumnName("End_Time");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(e => e.PermissionId).HasName("PK__Role_Per__89B744E583F451AB");

                entity.ToTable("Role_Permissions");

                entity.Property(e => e.PermissionId)
                    .ValueGeneratedNever()
                    .HasColumnName("Permission_ID");
                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
                entity.Property(e => e.RoleId).HasColumnName("Role_ID");

                entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__Role_Perm__Role___2F10007B");
            });

            modelBuilder.Entity<UserHistory>(entity =>
            {
                entity.HasKey(e => e.HistoryId).HasName("PK__UserHistory__8C4D3BBBA4A0D430");
                entity.ToTable("User_History");
                entity.Property(e => e.HistoryId).ValueGeneratedNever().HasColumnName("History_ID");
                entity.Property(e => e.UserId).HasColumnName("User_ID");
                entity.Property(e => e.Action).HasMaxLength(255).IsUnicode(false).HasColumnName("Action");
                entity.Property(e => e.Timestamp).HasColumnName("Timestamp");
            });

            modelBuilder.Entity<ForumComment>(entity =>
            {
                entity.HasKey(e => e.CommentId).HasName("PK__ForumComment__8C4D3BBBA4A0D430");
                entity.ToTable("Forum_Comments");
                entity.Property(e => e.CommentId).ValueGeneratedNever().HasColumnName("Comment_ID");
                entity.Property(e => e.UserId).HasColumnName("User_ID");
                entity.Property(e => e.PostId).HasColumnName("Post_ID");
                entity.Property(e => e.Content).HasMaxLength(1000).IsUnicode(false).HasColumnName("Content");
                entity.Property(e => e.Timestamp).HasColumnName("Timestamp");

                entity.HasOne(d => d.User).WithMany(p => p.ForumComments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ForumComment__User");

                entity.HasOne(d => d.Post).WithMany(p => p.ForumComments)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__ForumComment__Post");
            });

            

         

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public static class DbInitializer
        {
            public static void Initialize(ForumContext context)
            {
                context.Database.EnsureCreated();

                if (context.UserAccounts.Any())
                {
                    return;   // Данные уже инициализированы
                }

                var adminRole = context.Roles.FirstOrDefault(r => r.Name == "Admin");
                var userRole = context.Roles.FirstOrDefault(r => r.Name == "Пользователь");

                if (adminRole == null || userRole == null)
                {
                    throw new Exception("Не найдены роли в базе данных.");
                }

                var users = new[]
                {
                    new UserAccount
                    {
                        Login = "admin",
                        Password = HashPassword("admin_password"),
                        RoleId = adminRole.RoleId,
                        Email = "admin@forum.com",
                        Status = "Active",
                        RegistrationDate = DateTime.Now,
                    },
                    new UserAccount
                    {
                        Login = "user",
                        Password = HashPassword("user_password"),
                        RoleId = userRole.RoleId,
                        Email = "user@forum.com",
                        Status = "Active",
                        RegistrationDate = DateTime.Now,
                    }
                };

                context.UserAccounts.AddRange(users);
                context.SaveChanges();
            }

            private static string HashPassword(string password)
            {
                var hashedBytes = System.Security.Cryptography.SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
