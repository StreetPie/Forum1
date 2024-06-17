namespace Forum1.Models.DBModels
{
    public class ProfileInformation
    {
        public int ProfileId { get; set; }

        public string ProfileName { get; set; }
        public int ContactId { get; set; }
        public int? UserId { get; set; }
        public string? Phone { get; set; }
        public string? EmailAddress { get; set; }
        public string? ContactInformation { get; set; }

        public virtual UserAccount? User { get; set; }
        public ICollection<ForumPost> ForumPosts { get; set; }
    }
}