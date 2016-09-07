using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Web.Models
{
    public class AccountViewModel
    {
        public int ID { get; set; }
        public string AccountName { get; set; }
        public string CardNumber { get; set; }
        public long ExpirationYear { get; set; }
        public int ExpirationMonth { get; set; }
        public int CvvNumber { get; set; }

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
                CardNumber = this.CardNumber,
                ExpirationYear = this.ExpirationYear,
                ExpirationMonth = this.ExpirationMonth,
                CvvNumber = this.CvvNumber
            };
        }

        public AccountViewModel SingleAccountMap(Account a)
        {
            ID = a.ID;
            AccountName = a.AccountName;
            CardNumber = a.CardNumber;
            ExpirationYear = a.ExpirationMonth;
            ExpirationMonth = a.ExpirationMonth;
            CvvNumber = a.CvvNumber;
            return this;
        }
    }
}