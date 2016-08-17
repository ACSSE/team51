using Bursify.Data.EF.Entities.Campaigns;

namespace Bursify.Web.Models
{
    public class AccountViewModel
    {
        public int ID { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }

        public AccountViewModel()
        {
        }

        public AccountViewModel(Account a)
        {
            SingleAccountMap(a);
        }

        public Account ReverseMap()
        {
            return new Account()
            {
                ID = this.ID,
                AccountName = this.AccountName,
                AccountNumber = this.AccountNumber,
                BankName = this.BankName,
                BranchName = this.BranchName,
                BranchCode = this.BranchCode
            };
        }

        public AccountViewModel SingleAccountMap(Account a)
        {
            ID = a.ID;
            AccountName = a.AccountName;
            AccountNumber = a.AccountNumber;
            BankName = a.BankName;
            BranchName = a.BranchName;
            BranchCode = a.BranchCode;
            return this;
        }
    }
}