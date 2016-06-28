using Bursify.Data.EF;
using Bursify.Data.User;

namespace Bursify.Data.CampaignUser
{
    public class Account 
    {
        public int BursifyUserId { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
    }
}