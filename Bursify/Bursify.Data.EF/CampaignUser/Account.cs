namespace Bursify.Data.EF.CampaignUser
{
    public class Account : IEntity 
    {
        public int CampaignId { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string BranchName {
            get; set; }
        public string BranchCode { get; set; }

        public int Id
        {
            get { return CampaignId; }
        }

        public virtual Campaign Campaign { get; set; }
    }
}