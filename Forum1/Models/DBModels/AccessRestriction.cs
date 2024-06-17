namespace Forum1.Models.DBModels
{
    public partial class AccessRestriction
    {
        public int RestrictionId { get; set; }

        public int? AccountId { get; set; }

        public DateOnly? AccessFrom { get; set; }

        public DateOnly? AccessTo { get; set; }

        public string? Ip { get; set; }

        public virtual UserAccount? UserAccount { get; set; }
    }
}