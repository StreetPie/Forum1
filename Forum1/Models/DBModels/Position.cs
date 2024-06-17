namespace Forum1.Models.DBModels
{
    public partial class Position
    {
        public int PositionId { get; set; }

        public string? Name { get; set; }

        public virtual ICollection<UserHistory> UserHistories { get; set; } = new List<UserHistory>();
    }
}       