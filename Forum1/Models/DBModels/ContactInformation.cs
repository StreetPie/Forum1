namespace Forum1.Models.DBModels
{
    public partial class ContactInformation
    {
        public int ContactId { get; set; }

        public int? AccountId { get; set; }

        public string? Phone { get; set; }

        public string? EmailAddress { get; set; }

        public virtual UserAccount? UserAccount { get; set; }
    }
}