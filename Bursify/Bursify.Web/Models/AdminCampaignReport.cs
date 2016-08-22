namespace Bursify.Web.Models
{
    public class AdminCampaignReport
    {
        public int active { get; set; }
        public int completed { get; set; }
        public int cancelled { get; set; }

        public AdminCampaignReport()
        {
        }

        public AdminCampaignReport(int active, int completed, int cancelled)
        {
            this.active = active;
            this.completed = completed;
            this.cancelled = cancelled;
        }
    }
}