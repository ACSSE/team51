using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bursify.Entities.CampaignEntities
{
    public class Account : IEntityBase
    {
        public int CampaignId { get; set; }
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string BranchName
        {
            get; set;
        }
        public string BranchCode { get; set; }

        public int ID
        {
            get { return CampaignId; }
        }

        public virtual Campaign Campaign { get; set; }
    }
}
