namespace Forum1.Models.DBModels
{
    public partial class AccessLog
    {
        public int LogId { get; set; }
        public DateTime AccessTime { get; set; }
        public int AccountId { get; set; }
        public string ActionPerformed { get; set; }
        public virtual UserAccount Account { get; set; }
    }
}