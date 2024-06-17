using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Forum1.Models.DBModels
{
    public partial class UserAccount
    {
        private static readonly List<Notification> notifications = [];

        [Key]
        public int AccountId { get; set; }

        [Required]
        [StringLength(50)]
        public string? Login { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public string? FullName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string? Password { get; set; }

        public DateOnly LastLogin { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime? DateOfBirth { get; set; }


        [Required]
        public int RoleId { get; set; }

        public virtual UserRole? Role { get; set; }

        [Required]
        public ICollection<ContactInformation> ContactInformations { get; set; } = [];

        public string? Status { get; set; } // "Active", "Inactive"

        public virtual ProfileInformation Profile { get; set; }

        public virtual ICollection<ForumPost> ForumPosts { get; set; } = [];

        public virtual ICollection<ForumComment> ForumComments { get; set; } = [];


        public virtual ICollection<AccessLog> AccessLogs { get; set; } = [];

        public virtual ICollection<UserRole> Roles { get; set; } = [];

        public virtual ICollection<UserHistory> UserLoginHistories { get; set; } = [];

        public virtual ICollection<Notification> Notifications { get; set; } = notifications;

        public virtual ICollection<AccessRestriction> AccessRestrictions { get; set; } = [];
    }
}