namespace Forum1.Models.DBModels
{
    public partial class ScienceSchedule
    {
        public int ScheduleId { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}