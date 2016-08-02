using Bursify.Data.EF.Entities.Campaigns;
using Bursify.Data.EF.Entities.User;

namespace Bursify.Data.EF.Entities.Bridge
{
    public class CampaignReport : IBridgeEntity
    {
        public int CampaignId { get; set; }
        public int BursifyUserId { get; set; }
        public string Reason { get; set; }

        public virtual BursifyUser BursifyUser { get; set; }
        public virtual Campaign Campaign { get; set; }

        public int leftId
        {
            get { return CampaignId; }
        }

        public int rightId
        {
            get { return BursifyUserId; }
        }
    }
}
