using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum1.Models.DBModels
{
    public class Notification
    {
        [Key]
        public int NotificationId { get; set; }

        [Required]
        public int AccountId { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        [ForeignKey("AccountId")]
        public virtual UserAccount UserAccount { get; set; }
    }
}