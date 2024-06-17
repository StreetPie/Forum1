
namespace Forum1.Models.DBModels
{
    public partial class ForumComment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public virtual UserAccount User { get; set; }
        public virtual ForumPost Post { get; set; }
    }
}