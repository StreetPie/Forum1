namespace Forum1.Models.DBModels
{
    public partial class UserHistory
    {
        public int HistoryId { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public virtual UserAccount User { get; set; }
    }
}