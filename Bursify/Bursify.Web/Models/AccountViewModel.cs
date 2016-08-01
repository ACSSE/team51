﻿using Bursify.Data.EF.CampaignUser;

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

        public Account MapCamapignAccount(Account account)
        {
            return new Account()
            {
                ID = account.ID,
                AccountName = account.AccountName,
                AccountNumber = account.AccountNumber,
                BankName = account.BankName,
                BranchName = account.BranchName,
                BranchCode = account.BranchCode
            };
        }
    }
}