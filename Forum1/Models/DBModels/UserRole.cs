using Microsoft.Identity.Client;

namespace Forum1.Models.DBModels
{
    public partial class UserRole
    {
        public int RoleId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserAccount> UserAccount { get; set; } =[];
        public virtual ICollection<UserRole> AccountId  { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; } = [];
        public virtual ICollection<RolePermission> RolePermissions { get; set; } = [];
        public virtual ICollection<UserAccount> UserAccounts { get; set; } = [];
    }
}
