namespace Forum1.Models.DBModels
{
    public partial class RolePermission
    {
        public int PermissionId { get; set; }

        public int? RoleId { get; set; }

        public string? Name { get; set; }

        public virtual UserRole? Role { get; set; }
    }
}