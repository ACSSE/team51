using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Data.EF.Entities.Campaigns
{
    public class CampaignAccount : IEntity
    {
        public int ID { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string BranchName{  get; set; }
        public string BranchCode { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
