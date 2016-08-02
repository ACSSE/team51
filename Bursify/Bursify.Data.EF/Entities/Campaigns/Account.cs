namespace Bursify.Data.EF.Entities.Campaigns
{
    public class Account : IEntity 
    {
        public int ID { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string BranchName {get; set; }
        public string BranchCode { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}